using ZAP.Ecosystem.Domain.CRM.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZAP.Ecosystem.Domain.CRM
{
    [Table("uom", Schema = "platform")]
    public class UomItem
    {
        [Key]
        public int id { get; set; }

        [Column("serial_id")]
        public long? serial_id { get; set; }

        [Column("serial_number")]
        public string? serial_number { get; set; }

        [Column("code")]
        public string code { get; set; } = string.Empty;

        [Column("name")]
        public string name { get; set; } = string.Empty;

        [Column("short_name")]
        public string? short_name { get; set; }

        [Column("description")]
        public string? description { get; set; }

        /// <summary>Short symbol displayed in UI, e.g. "Kg", "L", "Box".</summary>
        [Column("symbol")]
        public string? abbreviation { get; set; }

        [Column("display_initial")]
        public string? display_initial { get; set; }

        /// <summary>Number of decimal places allowed (0–5).</summary>
        [Column("precision")]
        public int precision { get; set; } = 0;

        [Column("precision_digits")]
        public int? precision_digits { get; set; }

        [Column("conversion_rate")]
        public decimal? conversion_rate { get; set; }

        [Column("base_uom_id")]
        public int? base_uom_id { get; set; }

        [Column("is_active")]
        public bool is_active { get; set; } = true;

        [Column("status_id")]
        public int? status_id { get; set; }

        [ForeignKey("status_id")]
        public StatusItem? status { get; set; }

        [Column("created_at")]
        public DateTime? created_at { get; set; }

        [Column("updated_at")]
        public DateTime? updated_at { get; set; }

        // Navigation
        public ICollection<UomItemTranslation> translations { get; set; } = new List<UomItemTranslation>();
    }

    [Table("uom_translation", Schema = "platform")]
    public class UomItemTranslation
    {
        [Key]
        public Guid id { get; set; }

        [Column("uom_id")]
        public int uom_id { get; set; }

        [Column("locale_id")]
        public int locale_id { get; set; }

        [Column("name")]
        public string? name { get; set; }

        [Column("description")]
        public string? description { get; set; }
    }
}
