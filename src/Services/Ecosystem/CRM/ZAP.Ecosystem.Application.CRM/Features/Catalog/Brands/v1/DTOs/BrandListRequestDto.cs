using System.Text.Json.Serialization;
using ZAP.Ecosystem.Application.CRM.Common;

namespace ZAP.Ecosystem.Application.CRM.Features.Brands.v1.DTOs
{
    public class BrandListRequestDto : BaseListRequestDto<BrandListFilterDto, BaseSortDto>
    {
    }

    public class BrandListFilterDto
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
}

