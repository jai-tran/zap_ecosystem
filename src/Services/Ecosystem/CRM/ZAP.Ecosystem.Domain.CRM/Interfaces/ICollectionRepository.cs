using ZAP.Ecosystem.Domain.CRM.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZAP.Ecosystem.Domain.CRM
{
    public interface ICollectionRepository
    {
        Task<Collection?> GetByIdAsync(Guid id);
        Task<(IEnumerable<Collection> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, Guid? tenantId = null, string? search = null, int? statusId = null, string sortField = "created_at", bool sortDescending = true);
        Task CreateAsync(Collection collection);
        Task UpdateAsync(Collection collection);
        Task DeleteAsync(Guid id);
        Task AddItemsAsync(Guid collectionId, IEnumerable<Guid> productIds);
        Task RemoveItemsAsync(Guid collectionId, IEnumerable<Guid> productIds);
    }
}



