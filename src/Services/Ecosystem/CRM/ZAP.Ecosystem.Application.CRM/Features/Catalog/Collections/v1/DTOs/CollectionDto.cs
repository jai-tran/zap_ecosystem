using System;
using System.Collections.Generic;
using ZAP.Ecosystem.Application.CRM.Common;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs
{
    public class CollectionDto
    {
        public Guid id { get; set; }
        public int? serial_id { get; set; }
        public Guid? tenant_id { get; set; }
        public string name { get; set; } = string.Empty;
        public string slug { get; set; } = string.Empty;
        public string? description_html { get; set; }
        public string? banner_url { get; set; }
        public int status_id { get; set; }
        public string? status_code { get; set; }
        public string? status_name { get; set; }
        public int sort_order { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public List<CollectionItemDto> items { get; set; } = new();
    }

    public class CollectionItemDto
    {
        public Guid product_id { get; set; }
        public string? product_name { get; set; }
        public int sort_order { get; set; }
        public bool debug_product_null { get; set; }
    }

    public class CollectionFilterDto
    {
        [System.Text.Json.Serialization.JsonPropertyName("status_id")]
        public int? StatusId { get; set; }
    }

    public class CollectionListRequestDto : BaseListRequestDto<CollectionFilterDto, BaseSortDto>
    {
    }

    public class CreateCollectionRequestDto
    {
        public string name { get; set; } = string.Empty;
        public string slug { get; set; } = string.Empty;
        public string? description_html { get; set; }
        public string? banner_url { get; set; }
        public int sort_order { get; set; }
        public int status_id { get; set; } = 1;
        public List<CollectionItemDto> items { get; set; } = new();
    }

    public class UpdateCollectionRequestDto
    {
        public string name { get; set; } = string.Empty;
        public string slug { get; set; } = string.Empty;
        public string? description_html { get; set; }
        public string? banner_url { get; set; }
        public int sort_order { get; set; }
        public int status_id { get; set; } = 1;
        public List<CollectionItemDto> items { get; set; } = new();
    }
}

