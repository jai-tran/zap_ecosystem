using System;

namespace ZAP.Ecosystem.Application.CRM.Features.Units.v1.DTOs
{
    public class UnitDto
    {
        public int id { get; set; }
        public Guid? tenant_id { get; set; }
        public string code { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string? symbol { get; set; }
        public int precision { get; set; }
        public int? status_id { get; set; }
        public string? status_code { get; set; }
        public string? status_name { get; set; }
        public bool is_active { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}

