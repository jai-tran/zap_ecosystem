using System.Text.Json.Serialization;

namespace ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.DTOs
{
    public class ModifierGroupListRequestDto : ZAP.Ecosystem.Application.CRM.Common.BaseListRequestDto<ModifierGroupListFilterDto, ZAP.Ecosystem.Application.CRM.Common.BaseSortDto>
    {
    }

    public class ModifierGroupListFilterDto
    {
        /// <summary>Filter by status_id. Null = all.</summary>
        [JsonPropertyName("status_id")]
        public int? StatusId { get; set; }

        /// <summary>
        /// Filter by display type derived from max_selection.
        /// "single" = max_selection == 1 | "multi" = max_selection > 1 | null = all.
        /// </summary>
        [JsonPropertyName("display_type")]
        public string? DisplayType { get; set; }
    }

    /// <summary>Sort config. field: "name" (default) | "sort_order"</summary>
    public class ModifierGroupListSortDto
    {
        [JsonPropertyName("field")]
        public string Field { get; set; } = "name";

        [JsonPropertyName("descending")]
        public bool Descending { get; set; } = false;
    }
}

