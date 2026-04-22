using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAP.Ecosystem.Shared.Entities;
using ZAP.Ecosystem.Shared.Responses;
using ZAP.Ecosystem.Infrastructure.Data;

namespace ZAP.Ecosystem.API.CRM.Controllers.v1.Dictionaries;

[ApiController]
[Route("api/v1/system/dictionaries")]
public class DictionariesController(EcosystemDbContext context) : ControllerBase
{
    public class DictionaryListRequestDto
    {
        public int page_index { get; set; } = 1;
        public int page_size { get; set; } = 50;
        public string? search { get; set; }
        public DictionaryFiltersDto? filters { get; set; }
        public DictionarySortDto? sort { get; set; }
    }

    public class DictionaryFiltersDto
    {
        public string? schema_name { get; set; }
    }

    public class DictionarySortDto
    {
        public string? field { get; set; }
        public bool descending { get; set; }
    }

    [HttpPost("entities/list")]
    public async Task<IActionResult> ListEntities([FromBody] DictionaryListRequestDto request)
    {
        var query = context.EntityDictionaries
            .Include(e => e.Fields)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.search))
        {
            var keyword = request.search.ToLower();
            query = query.Where(e => e.TableName.ToLower().Contains(keyword) || e.DisplayName.ToLower().Contains(keyword));
        }

        if (!string.IsNullOrEmpty(request.filters?.schema_name))
        {
            query = query.Where(e => e.SchemaName == request.filters.schema_name);
        }

        if (request.sort != null && !string.IsNullOrEmpty(request.sort.field))
        {
            var sortField = request.sort.field.ToLower();
            if (sortField == "created_at")
            {
                query = request.sort.descending ? query.OrderByDescending(e => e.CreatedAt) : query.OrderBy(e => e.CreatedAt);
            }
            else
            {
                query = request.sort.descending ? query.OrderByDescending(e => e.TableName) : query.OrderBy(e => e.TableName);
            }
        }
        else
        {
            query = query.OrderBy(e => e.SchemaName).ThenBy(e => e.TableName);
        }

        var totalItems = await query.CountAsync();

        var entities = await query
            .Skip((request.page_index - 1) * request.page_size)
            .Take(request.page_size)
            .ToListAsync();
            
        // Wrap inside standard pagination response if needed, 
        // but to keep compatibility with existing response format we use "items" and "total_items"
        // Wait, standard response should match CRM Response.
        // But for now let's just return the expected structure.
        return Ok(ApiResponse<object>.Ok(new {
            total_page = (int)Math.Ceiling(totalItems / (double)request.page_size),
            total_record = totalItems,
            page_index = request.page_index,
            page_size = request.page_size,
            items = entities
        }));
    }

    [HttpGet("entities/{schema}/{table}")]
    public async Task<IActionResult> GetEntity(string schema, string table)
    {
        var entity = await context.EntityDictionaries
            .Include(e => e.Fields.OrderBy(f => f.SortOrder))
            .FirstOrDefaultAsync(e => e.SchemaName == schema && e.TableName == table);
            
        if (entity == null) return NotFound(ApiResponse<EntityDictionary>.Failure(404, "Entity dictionary Not Found"));
        
        return Ok(ApiResponse<EntityDictionary>.Ok(entity));
    }

    [HttpPost("entities")]
    public async Task<IActionResult> CreateEntity([FromBody] EntityDictionary entity)
    {
        entity.Id = Guid.NewGuid();
        entity.CreatedAt = DateTime.UtcNow;
        
        context.EntityDictionaries.Add(entity);
        await context.SaveChangesAsync();
        
        return Ok(ApiResponse<EntityDictionary>.Ok(entity, "Created successfully"));
    }

    [HttpPost("fields")]
    public async Task<IActionResult> CreateField([FromBody] EntityFieldDictionary field)
    {
        field.Id = Guid.NewGuid();
        field.CreatedAt = DateTime.UtcNow;
        
        context.EntityFieldDictionaries.Add(field);
        await context.SaveChangesAsync();
        
        return Ok(ApiResponse<EntityFieldDictionary>.Ok(field, "Created successfully"));
    }

    [HttpPut("fields/{id:guid}")]
    public async Task<IActionResult> UpdateField(Guid id, [FromBody] EntityFieldDictionary request)
    {
        var field = await context.EntityFieldDictionaries.FindAsync(id);
        if (field == null) return NotFound(ApiResponse<EntityFieldDictionary>.Failure(404, "Field dictionary Not Found"));
        
        field.DisplayName = request.DisplayName;
        field.IsVisibleList = request.IsVisibleList;
        field.IsVisibleDetail = request.IsVisibleDetail;
        field.IsRequired = request.IsRequired;
        field.SortOrder = request.SortOrder;
        // Keep existing properties intact
        field.UpdatedAt = DateTime.UtcNow;
        
        await context.SaveChangesAsync();
        return Ok(ApiResponse<EntityFieldDictionary>.Ok(field, "Updated successfully"));
    }
}
