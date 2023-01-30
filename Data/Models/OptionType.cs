namespace Data.Models;

public class OptionType
{
    public long ID { get; set; }
    public long TypID { get; set; }
    public string Name { get; set; }
    public Typ Typ { get; set; }
    public List<Option> Options { get; set; }
}