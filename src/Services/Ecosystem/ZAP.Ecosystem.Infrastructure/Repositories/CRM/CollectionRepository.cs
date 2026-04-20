using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZAP.Ecosystem.Domain.CRM;
using ZAP.Ecosystem.Infrastructure.Data;
using ZAP.Ecosystem.Shared.Data;

namespace ZAP.Ecosystem.Infrastructure.Repositories.CRM
{
    public class CollectionRepository : BaseRepository<Collection>, ICollectionRepository
    {
        public CollectionRepository(EcosystemDbContext context) : base(context)
        {
        }

        public async Task<(IEnumerable<Collection> Items, int TotalCount)> GetPagedAsync(
            int page, int pageSize, Guid? tenantId = null, string? search = null, int? statusId = null, string sortField = "created_at", bool sortDescending = true)
        {
            var query = _dbContext.Set<Collection>()
                .Include(x => x.status)
                .ThenInclude(s => s.translations)
                .AsNoTracking();

            if (tenantId.HasValue)
                query = query.Where(x => x.tenant_id == tenantId.Value);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                query = query.Where(x => 
                    (x.name != null && x.name.ToLower().Contains(lowerSearch)) ||
                    (x.slug != null && x.slug.ToLower().Contains(lowerSearch))
                );
            }

            if (statusId.HasValue)
                query = query.Where(x => x.status_id == statusId.Value);

            var normalizedSortField = sortField?.ToLower() ?? "created_at";
            query = normalizedSortField switch
            {
                "id" => sortDescending ? query.OrderByDescending(x => x.id) : query.OrderBy(x => x.id),
                "name" => sortDescending ? query.OrderByDescending(x => x.name) : query.OrderBy(x => x.name),
                "slug" => sortDescending ? query.OrderByDescending(x => x.slug) : query.OrderBy(x => x.slug),
                "sort_order" => sortDescending ? query.OrderByDescending(x => x.sort_order) : query.OrderBy(x => x.sort_order),
                "status_id" => sortDescending ? query.OrderByDescending(x => x.status_id) : query.OrderBy(x => x.status_id),
                "created_at" => sortDescending ? query.OrderByDescending(x => x.created_at) : query.OrderBy(x => x.created_at),
                "updated_at" => sortDescending ? query.OrderByDescending(x => x.updated_at) : query.OrderBy(x => x.updated_at),
                _ => sortDescending ? query.OrderByDescending(x => x.created_at) : query.OrderBy(x => x.created_at)
            };

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task CreateAsync(Collection collection)
        {
            await _dbSet.AddAsync(collection);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Collection collection)
        {
            _dbContext.Entry(collection).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AddItemsAsync(Guid collectionId, IEnumerable<Guid> productIds)
        {
            // Implementation for collection items
            await Task.CompletedTask;
        }

        public async Task RemoveItemsAsync(Guid collectionId, IEnumerable<Guid> productIds)
        {
            await Task.CompletedTask;
        }

        Task<Collection?> ICollectionRepository.GetByIdAsync(Guid id) => GetByIdAsync(id);
    }
}
