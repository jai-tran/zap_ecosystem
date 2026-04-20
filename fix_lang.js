const fs = require('fs');
const path = require('path');

const translationMap = {
    'CustomerGroup': 'Translations',
    'GeoCountry': 'Translations',
    'GeoProvince': 'translations',
    'PaymentMethod': 'Translations',
    'PaymentTerms': 'Translations',
    'PaymentType': 'Translations',
    'Promotion': 'Translations',
    'PromotionEntity': 'Translations',
    'ReportTemplate': 'Translations'
};

const repoDirs = [
    'src/Services/Ecosystem/ZAP.Ecosystem.Infrastructure/Repositories/CRM',
    'src/Services/Ecosystem/ZAP.Ecosystem.Infrastructure/Data/Repositories/CRM'
];
const handlerDir = 'src/Services/Ecosystem/CRM/ZAP.Ecosystem.Application.CRM/Features';

function walkDir(dir, callback) {
    if(!fs.existsSync(dir)) return;
    fs.readdirSync(dir).forEach(f => {
        let dirPath = path.join(dir, f);
        let isDirectory = fs.statSync(dirPath).isDirectory();
        isDirectory ? walkDir(dirPath, callback) : callback(dirPath);
    });
}

// 1. Process Repositories
repoDirs.forEach(dir => {
    walkDir(dir, (filePath) => {
        if (!filePath.endsWith('.cs')) return;
        let content = fs.readFileSync(filePath, 'utf8');
        let modified = content;
        
        let dbSetMatch = content.match(/_context\.([a-zA-Z]+)/);
        if (!dbSetMatch) return;
        let dbSet = dbSetMatch[1];
        
        // Exact name checking
        let nameBase = path.basename(filePath, 'Repository.cs');
        if (translationMap[nameBase]) {
            let prop = translationMap[nameBase];
            
            let regexQueryable = new RegExp(`_context\\.${dbSet}\\.AsQueryable\\(\\)(?!\\.Include)`, 'g');
            modified = modified.replace(regexQueryable, `_context.${dbSet}.Include(x => x.${prop}).AsQueryable()`);
            
            let regexAsNoTracking = new RegExp(`_context\\.${dbSet}\\.AsNoTracking\\(\\)(?!\\.Include)`, 'g');
            modified = modified.replace(regexAsNoTracking, `_context.${dbSet}.Include(x => x.${prop}).AsNoTracking()`);
            
            let regexWhere = new RegExp(`_context\\.${dbSet}\\.Where\\(`, 'g');
            modified = modified.replace(regexWhere, `_context.${dbSet}.Include(x => x.${prop}).Where(`);
            
            let regexFirst = new RegExp(`_context\\.${dbSet}\\.FirstOrDefaultAsync\\(`, 'g');
            modified = modified.replace(regexFirst, `_context.${dbSet}.Include(x => x.${prop}).FirstOrDefaultAsync(`);
        }

        if (content !== modified) {
            if (!modified.includes('using Microsoft.EntityFrameworkCore;')) {
                modified = 'using Microsoft.EntityFrameworkCore;\n' + modified;
            }
            fs.writeFileSync(filePath, modified, 'utf8');
            console.log('Updated Repo: ' + filePath);
        }
    });
});

// 2. Process Handlers
walkDir(handlerDir, (filePath) => {
    if (!filePath.endsWith('.cs')) return;
    if (!filePath.includes('Handler') && !filePath.includes('Query.cs')) return;
    
    let content = fs.readFileSync(filePath, 'utf8');
    let modified = content;
    
    let hasTranslation = false;
    let transProp = 'Translations';
    let entityMatch = content.match(/<([A-Za-z]+Dto)>/) || content.match(/([A-Za-z]+)Dto/);
    if (!entityMatch) return;
    
    let baseName = entityMatch[1].replace('Dto',''); 
    
    if (translationMap[baseName]) {
        hasTranslation = true;
        transProp = translationMap[baseName];
    } else if (baseName === 'Province') {
        hasTranslation = true;
        transProp = 'translations';
    }

    if (hasTranslation) {
        // Inject localeId logic safely
        if (!modified.includes('var localeId = _currentUserService.LocaleId;')) {
            modified = modified.replace(/Task<object> Handle\([^)]+\)\s*\{/, function(m) {
                return m + '\n            var localeId = _currentUserService.LocaleId;\n';
            });
            if (!modified.includes('_currentUserService')) {
                let classMatch = modified.match(/public class (\w+) : IRequestHandler/);
                if (classMatch) {
                    let className = classMatch[1];
                    modified = modified.replace(new RegExp(`public ${className}\\((.*?)\\)\\s*\\{`), function(m, args) {
                        return `private readonly ICurrentUserService _currentUserService;\n\n        public ${className}(${args ? args + ', ' : ''}ICurrentUserService currentUserService)\n        {\n            _currentUserService = currentUserService;`;
                    });
                     if (!modified.includes('using ZAP.Ecosystem.Domain.CRM.Interfaces;')) {
                        modified = 'using ZAP.Ecosystem.Domain.CRM.Interfaces;\n' + modified;
                    }
                }
            }
        }

        // Specifically fix GeoCountry which uses FirstOrDefault()?.name
        modified = modified.replace(/Translations\?\.FirstOrDefault\(\)\?\.name/g, 
            `Translations?.FirstOrDefault(t => t.locale_id == localeId)?.name`);
            
        // Fix explicit `name = x.name` where applicable
        const nameRegex = /name\s*=\s*([a-zA-Z0-9_]+)\.name(\s*\?\?\s*string\.Empty)?\s*(,|$)/g;
        modified = modified.replace(nameRegex, function(m, v, def, end) {
            return `name = ${v}.${transProp}?.FirstOrDefault(t => t.locale_id == localeId)?.name ?? ${v}.name ?? string.Empty${end}`;
        });
        
        // Similarly for description
        const descRegex = /description\s*=\s*([a-zA-Z0-9_]+)\.description(\s*\?\?\s*string\.Empty)?\s*(,|$)/g;
        modified = modified.replace(descRegex, function(m, v, def, end) {
            return `description = ${v}.${transProp}?.FirstOrDefault(t => t.locale_id == localeId)?.description ?? ${v}.description ?? string.Empty${end}`;
        });
    }

    if (content !== modified) {
        fs.writeFileSync(filePath, modified, 'utf8');
        console.log('Updated Handler: ' + filePath);
    }
});
