namespace Data.Models;

public class Typ
{
    public long ID { get; set; }
    public string Name { get; set; }
    public List<OptionType> OptionTypes { get; set; }
}