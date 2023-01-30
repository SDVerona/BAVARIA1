namespace Data.Models;

public class Model
{
    public long ID { get; set; }
    public string Name { get; set; }
    public long BasePrice { get; set; }
    public List<ModelOption> ModelOptions { get; set; }
}