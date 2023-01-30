using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class TypMap
{
    public TypMap(EntityTypeBuilder<Typ> builder)
    {
        builder.HasKey(x => x.ID);
    }
}