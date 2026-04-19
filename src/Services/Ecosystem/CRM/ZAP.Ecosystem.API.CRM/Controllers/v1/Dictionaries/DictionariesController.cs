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
    public class EntityFilterDto : ZAP.Ecosystem.Shared.Data.FilterDTOs
    {
        [System.Text.Json.Serialization.JsonPropertyName("schema_name")]
        public string? SchemaName { get; set; }
    }

    [HttpPost("entities/list")]
    public async Task<IActionResult> ListEntities([FromBody] EntityFilterDto filter)
    {
        var query = context.EntityDictionaries
            .Include(e => e.Fields)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Keyword))
        {
            query = query.Where(e => e.TableName.Contains(filter.Keyword) || e.DisplayName.Contains(filter.Keyword));
        }

        if (!string.IsNullOrEmpty(filter.SchemaName))
        {
            query = query.Where(e => e.SchemaName == filter.SchemaName);
        }

        var totalItems = await query.CountAsync();

        var entities = await query
            .OrderBy(e => e.SchemaName).ThenBy(e => e.TableName)
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();
            
        return Ok(ApiResponse<object>.Ok(new {
            items = entities,
            total_items = totalItems
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
