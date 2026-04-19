using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZAP.Ecosystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDialingCodeToGeoCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bom_header_product_variants_variantid",
                schema: "inventory",
                table: "bom_header");

            migrationBuilder.DropForeignKey(
                name: "fk_brand_status_item_status_id",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_item_location_locationid",
                schema: "inventory",
                table: "inventory_item");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_item_product_variants_variantid",
                schema: "inventory",
                table: "inventory_item");

            migrationBuilder.DropForeignKey(
                name: "fk_menu_item_hds_product_variants_variantid",
                schema: "sales",
                table: "menu_item_hds");

            migrationBuilder.DropForeignKey(
                name: "fk_product_product_type_item_product_typeid",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "fk_product_status_item_statusid",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "fk_product_category_map_category_categoryid",
                schema: "catalog",
                table: "product_category_map");

            migrationBuilder.DropForeignKey(
                name: "fk_product_category_map_product_productid",
                schema: "catalog",
                table: "product_category_map");

            migrationBuilder.DropForeignKey(
                name: "fk_product_location_pricing_product_variants_variantid",
                schema: "catalog",
                table: "product_location_pricing");

            migrationBuilder.DropForeignKey(
                name: "fk_product_media_product_variants_variantid",
                schema: "catalog",
                table: "product_media");

            migrationBuilder.DropForeignKey(
                name: "fk_product_variants_product_productid",
                schema: "catalog",
                table: "product_variants");

            migrationBuilder.DropForeignKey(
                name: "fk_product_variants_uom_item_uomid",
                schema: "catalog",
                table: "product_variants");

            migrationBuilder.DropForeignKey(
                name: "fk_uom_item_status_item_status_id",
                schema: "catalog",
                table: "uom_item");

            migrationBuilder.DropForeignKey(
                name: "fk_uom_item_translation_uom_item_uom_itemid",
                schema: "platform",
                table: "uom_item_translation");

            migrationBuilder.DropIndex(
                name: "ix_product_media_variantid",
                schema: "catalog",
                table: "product_media");

            migrationBuilder.DropIndex(
                name: "ix_product_location_pricing_variantid",
                schema: "catalog",
                table: "product_location_pricing");

            migrationBuilder.DropIndex(
                name: "ix_product_category_map_categoryid",
                schema: "catalog",
                table: "product_category_map");

            migrationBuilder.DropIndex(
                name: "ix_product_category_map_productid",
                schema: "catalog",
                table: "product_category_map");

            migrationBuilder.DropIndex(
                name: "ix_product_product_typeid",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropIndex(
                name: "ix_product_statusid",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropIndex(
                name: "ix_bom_header_variantid",
                schema: "inventory",
                table: "bom_header");

            migrationBuilder.DropIndex(
                name: "ix_inventory_item_locationid",
                schema: "inventory",
                table: "inventory_item");

            migrationBuilder.DropIndex(
                name: "ix_inventory_item_variantid",
                schema: "inventory",
                table: "inventory_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_uom_item_translation",
                schema: "platform",
                table: "uom_item_translation");

            migrationBuilder.DropIndex(
                name: "ix_uom_item_translation_uom_itemid",
                schema: "platform",
                table: "uom_item_translation");

            migrationBuilder.DropPrimaryKey(
                name: "pk_uom_item",
                schema: "catalog",
                table: "uom_item");

            migrationBuilder.DropIndex(
                name: "ix_uom_item_status_id",
                schema: "catalog",
                table: "uom_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product_variants",
                schema: "catalog",
                table: "product_variants");

            migrationBuilder.DropIndex(
                name: "ix_product_variants_productid",
                schema: "catalog",
                table: "product_variants");

            migrationBuilder.DropIndex(
                name: "ix_product_variants_uomid",
                schema: "catalog",
                table: "product_variants");

            migrationBuilder.DropColumn(
                name: "variantid",
                schema: "catalog",
                table: "product_media");

            migrationBuilder.DropColumn(
                name: "variantid",
                schema: "catalog",
                table: "product_location_pricing");

            migrationBuilder.DropColumn(
                name: "categoryid",
                schema: "catalog",
                table: "product_category_map");

            migrationBuilder.DropColumn(
                name: "productid",
                schema: "catalog",
                table: "product_category_map");

            migrationBuilder.DropColumn(
                name: "product_typeid",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropColumn(
                name: "statusid",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "system",
                table: "entity_field_dictionary");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "system",
                table: "entity_field_dictionary");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "system",
                table: "entity_field_dictionary");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "system",
                table: "entity_dictionary");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "system",
                table: "entity_dictionary");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "system",
                table: "entity_dictionary");

            migrationBuilder.DropColumn(
                name: "variantid",
                schema: "inventory",
                table: "bom_header");

            migrationBuilder.DropColumn(
                name: "locationid",
                schema: "inventory",
                table: "inventory_item");

            migrationBuilder.DropColumn(
                name: "variantid",
                schema: "inventory",
                table: "inventory_item");

            migrationBuilder.DropColumn(
                name: "uom_itemid",
                schema: "platform",
                table: "uom_item_translation");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "catalog",
                table: "uom_item");

            migrationBuilder.DropColumn(
                name: "productid",
                schema: "catalog",
                table: "product_variants");

            migrationBuilder.DropColumn(
                name: "uomid",
                schema: "catalog",
                table: "product_variants");

            migrationBuilder.EnsureSchema(
                name: "logistics");

            migrationBuilder.RenameTable(
                name: "status_item",
                schema: "core",
                newName: "status_item",
                newSchema: "system");

            migrationBuilder.RenameTable(
                name: "inventory_item",
                schema: "inventory",
                newName: "inventory_item",
                newSchema: "logistics");

            migrationBuilder.RenameTable(
                name: "uom_item_translation",
                schema: "platform",
                newName: "uom_translation",
                newSchema: "platform");

            migrationBuilder.RenameTable(
                name: "uom_item",
                schema: "catalog",
                newName: "uom",
                newSchema: "platform");

            migrationBuilder.RenameTable(
                name: "product_variants",
                schema: "catalog",
                newName: "product_variant",
                newSchema: "catalog");

            migrationBuilder.RenameColumn(
                name: "location_id",
                schema: "catalog",
                table: "product_location_pricing",
                newName: "warehouse_id");

            migrationBuilder.RenameColumn(
                name: "location_id",
                schema: "logistics",
                table: "inventory_item",
                newName: "warehouse_id");

            migrationBuilder.RenameColumn(
                name: "uom_item_id",
                schema: "platform",
                table: "uom_translation",
                newName: "uom_id");

            migrationBuilder.RenameColumn(
                name: "abbreviation",
                schema: "platform",
                table: "uom",
                newName: "symbol");

            migrationBuilder.RenameColumn(
                name: "status_id",
                schema: "platform",
                table: "uom",
                newName: "precision_digits");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "catalog",
                table: "product_location_pricing",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "system",
                table: "geo_country_translation",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "dialing_code",
                schema: "system",
                table: "geo_country",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "applicable_channels",
                schema: "catalog",
                table: "category",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(JsonDocument),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "website_url",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                schema: "catalog",
                table: "brand",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "serial_id",
                schema: "catalog",
                table: "brand",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "logo_url",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "banner_url",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "billing_currency",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "billing_setting_key",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<JsonDocument>(
                name: "billing_settings",
                schema: "catalog",
                table: "brand",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brand_code",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brand_color",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "business_name",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "canonical_url",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cover_image_url",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "catalog",
                table: "brand",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "display_initial",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<JsonDocument>(
                name: "display_settings",
                schema: "catalog",
                table: "brand",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_featured",
                schema: "catalog",
                table: "brand",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "landing_page_locale",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "landing_page_url",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "legacy_id",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "meta_description",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<JsonDocument>(
                name: "meta_keywords",
                schema: "catalog",
                table: "brand",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "meta_title",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reference_id",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "seo_metadata",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serial_number",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "short_description",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<JsonDocument>(
                name: "social_links",
                schema: "catalog",
                table: "brand",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tax_form_type",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tax_id",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "catalog",
                table: "brand",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "logistics",
                table: "inventory_item",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "platform",
                table: "uom_translation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "base_uom_id",
                schema: "platform",
                table: "uom",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "conversion_rate",
                schema: "platform",
                table: "uom",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "platform",
                table: "uom",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "platform",
                table: "uom",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "display_initial",
                schema: "platform",
                table: "uom",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "platform",
                table: "uom",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "serial_id",
                schema: "platform",
                table: "uom",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serial_number",
                schema: "platform",
                table: "uom",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "short_name",
                schema: "platform",
                table: "uom",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "platform",
                table: "uom",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_uom_translation",
                schema: "platform",
                table: "uom_translation",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_uom",
                schema: "platform",
                table: "uom",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_product_variant",
                schema: "catalog",
                table: "product_variant",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_product_media_product_variant_id",
                schema: "catalog",
                table: "product_media",
                column: "product_variant_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_category_map_category_id",
                schema: "catalog",
                table: "product_category_map",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_product_type_id",
                schema: "catalog",
                table: "product",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_status_id",
                schema: "catalog",
                table: "product",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_bom_header_product_variant_id",
                schema: "inventory",
                table: "bom_header",
                column: "product_variant_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_item_product_variant_id",
                schema: "logistics",
                table: "inventory_item",
                column: "product_variant_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_item_warehouse_id",
                schema: "logistics",
                table: "inventory_item",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "ix_uom_translation_uom_id",
                schema: "platform",
                table: "uom_translation",
                column: "uom_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_variant_product_id",
                schema: "catalog",
                table: "product_variant",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_variant_uom_id",
                schema: "catalog",
                table: "product_variant",
                column: "uom_id");

            migrationBuilder.AddForeignKey(
                name: "fk_bom_header_product_variant_product_variant_id",
                schema: "inventory",
                table: "bom_header",
                column: "product_variant_id",
                principalSchema: "catalog",
                principalTable: "product_variant",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_brand_status_item_status_id",
                schema: "catalog",
                table: "brand",
                column: "status_id",
                principalSchema: "system",
                principalTable: "status_item",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_item_location_warehouse_id",
                schema: "logistics",
                table: "inventory_item",
                column: "warehouse_id",
                principalSchema: "locations",
                principalTable: "location",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_item_product_variant_product_variant_id",
                schema: "logistics",
                table: "inventory_item",
                column: "product_variant_id",
                principalSchema: "catalog",
                principalTable: "product_variant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_menu_item_hds_product_variant_variantid",
                schema: "sales",
                table: "menu_item_hds",
                column: "variantid",
                principalSchema: "catalog",
                principalTable: "product_variant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_product_type_item_product_type_id",
                schema: "catalog",
                table: "product",
                column: "product_type_id",
                principalSchema: "catalog",
                principalTable: "product_type_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_status_item_status_id",
                schema: "catalog",
                table: "product",
                column: "status_id",
                principalSchema: "system",
                principalTable: "status_item",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_category_map_category_category_id",
                schema: "catalog",
                table: "product_category_map",
                column: "category_id",
                principalSchema: "catalog",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_category_map_product_product_id",
                schema: "catalog",
                table: "product_category_map",
                column: "product_id",
                principalSchema: "catalog",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_location_pricing_product_variant_product_variant_id",
                schema: "catalog",
                table: "product_location_pricing",
                column: "product_variant_id",
                principalSchema: "catalog",
                principalTable: "product_variant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_media_product_variant_product_variant_id",
                schema: "catalog",
                table: "product_media",
                column: "product_variant_id",
                principalSchema: "catalog",
                principalTable: "product_variant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_variant_product_product_id",
                schema: "catalog",
                table: "product_variant",
                column: "product_id",
                principalSchema: "catalog",
                principalTable: "product",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_variant_uom_uom_id",
                schema: "catalog",
                table: "product_variant",
                column: "uom_id",
                principalSchema: "platform",
                principalTable: "uom",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_uom_translation_uom_uom_id",
                schema: "platform",
                table: "uom_translation",
                column: "uom_id",
                principalSchema: "platform",
                principalTable: "uom",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bom_header_product_variant_product_variant_id",
                schema: "inventory",
                table: "bom_header");

            migrationBuilder.DropForeignKey(
                name: "fk_brand_status_item_status_id",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_item_location_warehouse_id",
                schema: "logistics",
                table: "inventory_item");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_item_product_variant_product_variant_id",
                schema: "logistics",
                table: "inventory_item");

            migrationBuilder.DropForeignKey(
                name: "fk_menu_item_hds_product_variant_variantid",
                schema: "sales",
                table: "menu_item_hds");

            migrationBuilder.DropForeignKey(
                name: "fk_product_product_type_item_product_type_id",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "fk_product_status_item_status_id",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "fk_product_category_map_category_category_id",
                schema: "catalog",
                table: "product_category_map");

            migrationBuilder.DropForeignKey(
                name: "fk_product_category_map_product_product_id",
                schema: "catalog",
                table: "product_category_map");

            migrationBuilder.DropForeignKey(
                name: "fk_product_location_pricing_product_variant_product_variant_id",
                schema: "catalog",
                table: "product_location_pricing");

            migrationBuilder.DropForeignKey(
                name: "fk_product_media_product_variant_product_variant_id",
                schema: "catalog",
                table: "product_media");

            migrationBuilder.DropForeignKey(
                name: "fk_product_variant_product_product_id",
                schema: "catalog",
                table: "product_variant");

            migrationBuilder.DropForeignKey(
                name: "fk_product_variant_uom_uom_id",
                schema: "catalog",
                table: "product_variant");

            migrationBuilder.DropForeignKey(
                name: "fk_uom_translation_uom_uom_id",
                schema: "platform",
                table: "uom_translation");

            migrationBuilder.DropIndex(
                name: "ix_product_media_product_variant_id",
                schema: "catalog",
                table: "product_media");

            migrationBuilder.DropIndex(
                name: "ix_product_category_map_category_id",
                schema: "catalog",
                table: "product_category_map");

            migrationBuilder.DropIndex(
                name: "ix_product_product_type_id",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropIndex(
                name: "ix_product_status_id",
                schema: "catalog",
                table: "product");

            migrationBuilder.DropIndex(
                name: "ix_bom_header_product_variant_id",
                schema: "inventory",
                table: "bom_header");

            migrationBuilder.DropIndex(
                name: "ix_inventory_item_product_variant_id",
                schema: "logistics",
                table: "inventory_item");

            migrationBuilder.DropIndex(
                name: "ix_inventory_item_warehouse_id",
                schema: "logistics",
                table: "inventory_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_uom_translation",
                schema: "platform",
                table: "uom_translation");

            migrationBuilder.DropIndex(
                name: "ix_uom_translation_uom_id",
                schema: "platform",
                table: "uom_translation");

            migrationBuilder.DropPrimaryKey(
                name: "pk_uom",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product_variant",
                schema: "catalog",
                table: "product_variant");

            migrationBuilder.DropIndex(
                name: "ix_product_variant_product_id",
                schema: "catalog",
                table: "product_variant");

            migrationBuilder.DropIndex(
                name: "ix_product_variant_uom_id",
                schema: "catalog",
                table: "product_variant");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "catalog",
                table: "product_location_pricing");

            migrationBuilder.DropColumn(
                name: "dialing_code",
                schema: "system",
                table: "geo_country");

            migrationBuilder.DropColumn(
                name: "billing_currency",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "billing_setting_key",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "billing_settings",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "brand_code",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "brand_color",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "business_name",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "canonical_url",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "cover_image_url",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "display_initial",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "display_settings",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "is_featured",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "landing_page_locale",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "landing_page_url",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "legacy_id",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "meta_description",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "meta_keywords",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "meta_title",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "reference_id",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "seo_metadata",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "serial_number",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "short_description",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "social_links",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "tax_form_type",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "tax_id",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "catalog",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "platform",
                table: "uom_translation");

            migrationBuilder.DropColumn(
                name: "base_uom_id",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropColumn(
                name: "conversion_rate",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropColumn(
                name: "display_initial",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropColumn(
                name: "is_active",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropColumn(
                name: "serial_id",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropColumn(
                name: "serial_number",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropColumn(
                name: "short_name",
                schema: "platform",
                table: "uom");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "platform",
                table: "uom");

            migrationBuilder.RenameTable(
                name: "status_item",
                schema: "system",
                newName: "status_item",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "inventory_item",
                schema: "logistics",
                newName: "inventory_item",
                newSchema: "inventory");

            migrationBuilder.RenameTable(
                name: "uom_translation",
                schema: "platform",
                newName: "uom_item_translation",
                newSchema: "platform");

            migrationBuilder.RenameTable(
                name: "uom",
                schema: "platform",
                newName: "uom_item",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "product_variant",
                schema: "catalog",
                newName: "product_variants",
                newSchema: "catalog");

            migrationBuilder.RenameColumn(
                name: "warehouse_id",
                schema: "catalog",
                table: "product_location_pricing",
                newName: "location_id");

            migrationBuilder.RenameColumn(
                name: "warehouse_id",
                schema: "inventory",
                table: "inventory_item",
                newName: "location_id");

            migrationBuilder.RenameColumn(
                name: "uom_id",
                schema: "platform",
                table: "uom_item_translation",
                newName: "uom_item_id");

            migrationBuilder.RenameColumn(
                name: "symbol",
                schema: "catalog",
                table: "uom_item",
                newName: "abbreviation");

            migrationBuilder.RenameColumn(
                name: "precision_digits",
                schema: "catalog",
                table: "uom_item",
                newName: "status_id");

            migrationBuilder.AddColumn<Guid>(
                name: "variantid",
                schema: "catalog",
                table: "product_media",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "variantid",
                schema: "catalog",
                table: "product_location_pricing",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "categoryid",
                schema: "catalog",
                table: "product_category_map",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "productid",
                schema: "catalog",
                table: "product_category_map",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_typeid",
                schema: "catalog",
                table: "product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "statusid",
                schema: "catalog",
                table: "product",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "system",
                table: "geo_country_translation",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "system",
                table: "entity_field_dictionary",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "system",
                table: "entity_field_dictionary",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "system",
                table: "entity_field_dictionary",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "system",
                table: "entity_dictionary",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "system",
                table: "entity_dictionary",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "system",
                table: "entity_dictionary",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "applicable_channels",
                schema: "catalog",
                table: "category",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "website_url",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                schema: "catalog",
                table: "brand",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "serial_id",
                schema: "catalog",
                table: "brand",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "logo_url",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "banner_url",
                schema: "catalog",
                table: "brand",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "variantid",
                schema: "inventory",
                table: "bom_header",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "inventory",
                table: "inventory_item",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "locationid",
                schema: "inventory",
                table: "inventory_item",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "variantid",
                schema: "inventory",
                table: "inventory_item",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "uom_itemid",
                schema: "platform",
                table: "uom_item_translation",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "catalog",
                table: "uom_item",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "productid",
                schema: "catalog",
                table: "product_variants",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "uomid",
                schema: "catalog",
                table: "product_variants",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_uom_item_translation",
                schema: "platform",
                table: "uom_item_translation",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_uom_item",
                schema: "catalog",
                table: "uom_item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_product_variants",
                schema: "catalog",
                table: "product_variants",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_product_media_variantid",
                schema: "catalog",
                table: "product_media",
                column: "variantid");

            migrationBuilder.CreateIndex(
                name: "ix_product_location_pricing_variantid",
                schema: "catalog",
                table: "product_location_pricing",
                column: "variantid");

            migrationBuilder.CreateIndex(
                name: "ix_product_category_map_categoryid",
                schema: "catalog",
                table: "product_category_map",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_product_category_map_productid",
                schema: "catalog",
                table: "product_category_map",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_product_product_typeid",
                schema: "catalog",
                table: "product",
                column: "product_typeid");

            migrationBuilder.CreateIndex(
                name: "ix_product_statusid",
                schema: "catalog",
                table: "product",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "ix_bom_header_variantid",
                schema: "inventory",
                table: "bom_header",
                column: "variantid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_item_locationid",
                schema: "inventory",
                table: "inventory_item",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_item_variantid",
                schema: "inventory",
                table: "inventory_item",
                column: "variantid");

            migrationBuilder.CreateIndex(
                name: "ix_uom_item_translation_uom_itemid",
                schema: "platform",
                table: "uom_item_translation",
                column: "uom_itemid");

            migrationBuilder.CreateIndex(
                name: "ix_uom_item_status_id",
                schema: "catalog",
                table: "uom_item",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_variants_productid",
                schema: "catalog",
                table: "product_variants",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_product_variants_uomid",
                schema: "catalog",
                table: "product_variants",
                column: "uomid");

            migrationBuilder.AddForeignKey(
                name: "fk_bom_header_product_variants_variantid",
                schema: "inventory",
                table: "bom_header",
                column: "variantid",
                principalSchema: "catalog",
                principalTable: "product_variants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_brand_status_item_status_id",
                schema: "catalog",
                table: "brand",
                column: "status_id",
                principalSchema: "core",
                principalTable: "status_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_item_location_locationid",
                schema: "inventory",
                table: "inventory_item",
                column: "locationid",
                principalSchema: "locations",
                principalTable: "location",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_item_product_variants_variantid",
                schema: "inventory",
                table: "inventory_item",
                column: "variantid",
                principalSchema: "catalog",
                principalTable: "product_variants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_menu_item_hds_product_variants_variantid",
                schema: "sales",
                table: "menu_item_hds",
                column: "variantid",
                principalSchema: "catalog",
                principalTable: "product_variants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_product_type_item_product_typeid",
                schema: "catalog",
                table: "product",
                column: "product_typeid",
                principalSchema: "catalog",
                principalTable: "product_type_item",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_status_item_statusid",
                schema: "catalog",
                table: "product",
                column: "statusid",
                principalSchema: "core",
                principalTable: "status_item",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_category_map_category_categoryid",
                schema: "catalog",
                table: "product_category_map",
                column: "categoryid",
                principalSchema: "catalog",
                principalTable: "category",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_category_map_product_productid",
                schema: "catalog",
                table: "product_category_map",
                column: "productid",
                principalSchema: "catalog",
                principalTable: "product",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_location_pricing_product_variants_variantid",
                schema: "catalog",
                table: "product_location_pricing",
                column: "variantid",
                principalSchema: "catalog",
                principalTable: "product_variants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_media_product_variants_variantid",
                schema: "catalog",
                table: "product_media",
                column: "variantid",
                principalSchema: "catalog",
                principalTable: "product_variants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_variants_product_productid",
                schema: "catalog",
                table: "product_variants",
                column: "productid",
                principalSchema: "catalog",
                principalTable: "product",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_variants_uom_item_uomid",
                schema: "catalog",
                table: "product_variants",
                column: "uomid",
                principalSchema: "catalog",
                principalTable: "uom_item",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_uom_item_status_item_status_id",
                schema: "catalog",
                table: "uom_item",
                column: "status_id",
                principalSchema: "core",
                principalTable: "status_item",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_uom_item_translation_uom_item_uom_itemid",
                schema: "platform",
                table: "uom_item_translation",
                column: "uom_itemid",
                principalSchema: "catalog",
                principalTable: "uom_item",
                principalColumn: "id");
        }
    }
}
