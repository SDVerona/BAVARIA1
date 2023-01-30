using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class ModelMap
{
    public ModelMap(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(x => x.ID);
    }
}
