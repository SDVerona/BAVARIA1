using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class OptionTypeMap
{
    public OptionTypeMap(EntityTypeBuilder<OptionType> builder)
    {
        builder.HasKey(x => x.ID);
        builder
            .HasOne(x => x.Typ)
            .WithMany(x => x.OptionTypes)
            .HasForeignKey(x => x.TypID);
    }
}
