using System.Text.Json.Serialization;
using ZAP.Ecosystem.Application.CRM.Common;

namespace ZAP.Ecosystem.Application.CRM.Features.Categories.v1.DTOs
{
    public class CategoryListRequestDto : BaseListRequestDto<CategoryListFilterDto, BaseSortDto>
    {
    }

    public class CategoryListFilterDto
    {
        [JsonPropertyName("status_id")]
        public int? StatusId { get; set; }

        [JsonPropertyName("parent_id")]
        public Guid? ParentId { get; set; }
    }
}

