namespace Api.Models;

public class AddModelRequest
{
    public long ID { get; set; }
    public string Name { get; set; }
    public long BasePrice { get; set; }
}