using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Infrastructure.Data.Repositories.CRM
{
    public class UnitRepository : IUnitRepository
    {
        private readonly EcosystemDbContext _context;
        public UnitRepository(EcosystemDbContext context) => _context = context;

        public async Task<IEnumerable<UomItem>> GetAllAsync(Guid? tenantId = null) => await _context.UomItems.Where(x => tenantId == null).ToListAsync();
        public async Task<UomItem?> GetByIdAsync(int id) => await _context.UomItems.Include(x => x.translations).FirstOrDefaultAsync(u => u.id == id);
        public async Task CreateAsync(UomItem uomItem) { _context.UomItems.Add(uomItem); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(UomItem uomItem) { _context.UomItems.Update(uomItem); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var u = await _context.UomItems.FindAsync(id); if (u != null) { _context.UomItems.Remove(u); await _context.SaveChangesAsync(); } }

        public async Task<(IEnumerable<UomItem> Items, int Total)> GetPagedAsync(
            int page, int pageSize, Guid? tenantId = null, string? search = null, int? statusId = null, int? precision = null, string sortField = "name", bool sortDescending = false)
        {
            var q = _context.UomItems.Include(x => x.translations).AsQueryable();

            if (!string.IsNullOrEmpty(search)) 
            {
                var lowerSearch = search.ToLower();
                q = q.Where(x => 
                    (x.name != null && x.name.ToLower().Contains(lowerSearch)) || 
                    (x.abbreviation != null && x.abbreviation.ToLower().Contains(lowerSearch)) ||
                    (x.code != null && x.code.ToLower().Contains(lowerSearch))
                );
            }

            if (precision.HasValue) 
            {
                q = q.Where(x => x.precision == precision);
            }
            
            if (statusId.HasValue) 
            {
                bool isActive = statusId.Value == 1;
                q = q.Where(x => x.is_active == isActive);
            }

            var normalizedSortField = sortField?.ToLower() ?? "name";
            q = normalizedSortField switch
            {
                "id" => sortDescending ? q.OrderByDescending(x => x.id) : q.OrderBy(x => x.id),
                "code" => sortDescending ? q.OrderByDescending(x => x.code) : q.OrderBy(x => x.code),
                "abbreviation" => sortDescending ? q.OrderByDescending(x => x.abbreviation) : q.OrderBy(x => x.abbreviation),
                "precision" => sortDescending ? q.OrderByDescending(x => x.precision) : q.OrderBy(x => x.precision),
                "is_active" => sortDescending ? q.OrderByDescending(x => x.is_active) : q.OrderBy(x => x.is_active),
                "status_id" => sortDescending ? q.OrderByDescending(x => x.is_active) : q.OrderBy(x => x.is_active),
                "created_at" => sortDescending ? q.OrderByDescending(x => x.created_at) : q.OrderBy(x => x.created_at),
                "updated_at" => sortDescending ? q.OrderByDescending(x => x.updated_at) : q.OrderBy(x => x.updated_at),
                _ => sortDescending ? q.OrderByDescending(x => x.name) : q.OrderBy(x => x.name)
            };

            int total = await q.CountAsync();
            var items = await q.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, total);
        }
    }
}
