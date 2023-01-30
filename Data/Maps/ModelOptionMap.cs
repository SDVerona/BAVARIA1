using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class ModelOptionMap
{
    public ModelOptionMap(EntityTypeBuilder<ModelOption> builder)
    {
        builder.HasKey(x => x.ID);
        builder
            .HasOne(x => x.Model)
            .WithMany(x => x.ModelOptions)
            .HasForeignKey(x => x.ModelID);
        builder
            .HasOne(x => x.Option)
            .WithMany(x => x.ModelOptions)
            .HasForeignKey(x => x.OptionID);
    }
}