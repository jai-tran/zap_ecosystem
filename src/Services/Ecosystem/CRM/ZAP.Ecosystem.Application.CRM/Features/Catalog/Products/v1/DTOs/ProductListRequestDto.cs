using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ZAP.Ecosystem.Application.CRM.Features.Products.v1.DTOs
{
    public class ProductListRequestDto : ZAP.Ecosystem.Application.CRM.Common.BaseListRequestDto<ProductListFilterDto, ZAP.Ecosystem.Application.CRM.Common.BaseSortDto>
    {
    }

    public class ProductListFilterDto
    {
        [JsonPropertyName("cate_id")]
        public string? CategoryId { get; set; }

        [JsonPropertyName("status")]
        public int? StatusId { get; set; }

        [JsonPropertyName("location_id")]
        public string? LocationId { get; set; }

        [JsonPropertyName("locale_id")]
        public int? LocaleId { get; set; }

        [JsonPropertyName("product_type_id")]
        public int? ProductTypeId { get; set; }
    }

    /// <summary>
    /// Sort config. field: "name" | "price" | "stock" | "created_at" (default)
    /// </summary>
    public class ProductListSortDto
    {
        [JsonPropertyName("field")]
        public string Field { get; set; } = "created_at";

        [JsonPropertyName("descending")]
        public bool Descending { get; set; } = true;
    }
}

