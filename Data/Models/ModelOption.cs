namespace Data.Models;

public class ModelOption
{
    public long ID { get; set; }
    public long ModelID { get; set; }
    public long OptionID { get; set; }
    public Model Model { get; set; }
    public Option Option { get; set; }
}