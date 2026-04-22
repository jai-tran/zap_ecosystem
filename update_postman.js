const fs = require('fs');
const file = 'ZAP_Ecosystem_Master_Suite_v3.postman_collection.json';
const data = JSON.parse(fs.readFileSync(file, 'utf8'));

function traverse(item) {
    if (item.request && item.request.url) {
        const urlObj = item.request.url;
        const urlStr = typeof urlObj === 'string' ? urlObj : (urlObj.raw || (urlObj.path ? urlObj.path.join('/') : ''));
        
        let currentBody = {};
        if (item.request.body && item.request.body.raw) {
            try {
                currentBody = JSON.parse(item.request.body.raw);
            } catch (e) {}
        }

        if (urlStr.includes('dictionaries/entities/list')) {
            const newBody = {
                page_index: 1,
                page_size: 50,
                search: "uom",
                filters: { schema_name: "platform" },
                sort: { field: "created_at", descending: true }
            };
            item.request.body = { mode: "raw", raw: JSON.stringify(newBody, null, 2), options: { raw: { language: "json" } } };
            
        } else if (urlStr.endsWith('/list')) {
            // Determine filter template based on URL path
            let filterTemplate = {};
            if (urlStr.includes('/products/') || urlStr.includes('/brands/')) {
                filterTemplate = { cate_id: null, status: 1, location_id: null, locale_id: null, product_type_id: null };
            } else if (urlStr.includes('/categories/')) {
                filterTemplate = { status_id: 1, parent_id: null };
            } else if (urlStr.includes('/units/')) {
                filterTemplate = { status_id: 1, precision: null, id: null, symbol: null };
            } else if (urlStr.includes('/locations/')) {
                filterTemplate = { status_id: 1, province_id: null, location_type_id: null };
            } else if (urlStr.includes('/modifieritems/')) {
                filterTemplate = { group_id: null, status_id: 1 };
            } else if (urlStr.includes('/modifiergroups/')) {
                filterTemplate = { status_id: 1 };
            } else if (urlStr.includes('/menus/') || urlStr.includes('/geo_countries/')) {
                filterTemplate = { is_active: true };
            }

            // Merge current filters with template to keep existing values, but show all keys
            const mergedFilters = Object.assign({}, filterTemplate, currentBody.filters || {});

            const newBody = {
                page_index: currentBody.page_index || currentBody.page || 1,
                page_size: currentBody.page_size || 50,
                search: currentBody.search || currentBody.keyword || "",
                filters: mergedFilters,
                sort: currentBody.sort || { field: "created_at", descending: true }
            };
            
            delete newBody.keyword;
            delete newBody.page;
            
            item.request.body = { mode: "raw", raw: JSON.stringify(newBody, null, 2), options: { raw: { language: "json" } } };
            
        } else if (urlStr.includes('catalog/locations') && item.request.method === 'POST') {
            const newBody = {
              name: "Cửa hàng Phở 24 - Quận 1",
              location_code: "LOC-001",
              business_name: "Phở 24",
              description: "Chi nhánh chính tại Quận 1",
              status_id: 30001,
              is_active: true,
              address_line_1: "123 Lê Lợi",
              city: "Hồ Chí Minh",
              state: "HCM",
              zipcode: "700000",
              phone_number: "0123456789",
              email: "contact@pho24.com",
              timezone: "Asia/Ho_Chi_Minh",
              latitude: 10.7769,
              longitude: 106.7009
            };
            item.request.body = { mode: "raw", raw: JSON.stringify(newBody, null, 2), options: { raw: { language: "json" } } };
        } else {
            if (item.request && item.request.body && item.request.body.raw) {
                try {
                    const parsed = JSON.parse(item.request.body.raw);
                    item.request.body.raw = JSON.stringify(parsed, null, 2);
                } catch (e) {}
            }
        }
    }
    
    if (item.item) {
        item.item.forEach(traverse);
    }
}

traverse({ item: data.item });
fs.writeFileSync(file, JSON.stringify(data, null, 2), 'utf8');
