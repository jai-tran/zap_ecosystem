using System.Text.Json.Serialization;

namespace ZAP.Ecosystem.Application.CRM.Common
{
    public class BaseListRequestDto<TFilter, TSort>
    {
        [JsonPropertyName("page_index")]
        public int PageIndex { get; set; } = 1;

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; } = 50;

        [JsonPropertyName("search")]
        public string? Search { get; set; } = string.Empty;

        [JsonPropertyName("filters")]
        public TFilter Filters { get; set; } = default!;

        [JsonPropertyName("sort")]
        public TSort Sort { get; set; } = default!;
    }

    public class BaseSortDto
    {
        [JsonPropertyName("field")]
        public string Field { get; set; } = "id";

        [JsonPropertyName("descending")]
        public bool Descending { get; set; } = false;
    }
}
