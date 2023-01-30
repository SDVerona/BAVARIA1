using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class OptionMap
{
    public OptionMap(EntityTypeBuilder<Option> builder)
    {
        builder.HasKey(x => x.ID);
        builder
            .HasOne(x => x.OptionType)
            .WithMany(x => x.Options)
            .HasForeignKey(x => x.OptionTypID);
    }
}