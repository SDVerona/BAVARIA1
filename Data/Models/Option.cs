namespace Data.Models;

public class Option
{
    public long ID { get; set; }
    public long OptionTypID { get; set; }
    public string Name { get; set; }
    public string IMG { get; set; }
    public long Price { get; set; }
    public List<ModelOption> ModelOptions { get; set; }
    public OptionType OptionType { get; set; }
}