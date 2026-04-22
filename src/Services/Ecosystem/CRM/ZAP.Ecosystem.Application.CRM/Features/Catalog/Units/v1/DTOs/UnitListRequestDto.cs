using System.Text.Json.Serialization;
using ZAP.Ecosystem.Application.CRM.Common;

namespace ZAP.Ecosystem.Application.CRM.Features.Units.v1.DTOs
{
    public class UnitListRequestDto : BaseListRequestDto<UnitListFilterDto, BaseSortDto>
    {
    }

    public class UnitListFilterDto
    {
        [JsonPropertyName("status_id")]
        public int? StatusId { get; set; }

        [JsonPropertyName("precision")]
        public int? Precision { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
    }
}

