namespace Data.Entities;

public class Tasting
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public List<Wine> Wines { get; set; } = new List<Wine>();
    public List<string> Guests { get; set; } = new List<string>();
}