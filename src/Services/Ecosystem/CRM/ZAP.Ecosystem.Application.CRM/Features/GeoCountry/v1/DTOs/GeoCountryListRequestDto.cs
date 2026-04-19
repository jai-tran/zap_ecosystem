using System.Text.Json.Serialization;
using ZAP.Ecosystem.Application.CRM.Common;

namespace ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.DTOs
{
    public class GeoCountryListRequestDto : BaseListRequestDto<GeoCountryListFilterDto, BaseSortDto>
    {
    }

    public class GeoCountryListFilterDto
    {
        [JsonPropertyName("is_active")]
        public bool? IsActive { get; set; }
    }
}
