namespace Api.Models;

public class AddOptionRequest

{
    public long ID { get; set; }
    public long OptionTypID { get; set; }
    public string Name { get; set; }
    public string IMG { get; set; }
    public long Price { get; set; }
}