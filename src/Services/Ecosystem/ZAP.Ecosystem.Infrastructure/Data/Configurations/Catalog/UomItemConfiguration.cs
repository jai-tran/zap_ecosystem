using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Infrastructure.Data.Configurations.Catalog;

public class UomItemConfiguration : IEntityTypeConfiguration<UomItem>
{
    public void Configure(EntityTypeBuilder<UomItem> builder)
    {
        builder.Metadata.SetSchema("platform");
        builder.ToTable("uom", "platform");
        builder.HasKey(x => x.id);

        builder.HasMany(x => x.translations)
               .WithOne()
               .HasForeignKey(t => t.uom_id);
    }
}
