namespace Data.DTO_s;

public class TastingForCreationDTO
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public List<int> WineIds { get; set; } = new List<int>();
    public List<string> Guests { get; set; } = new List<string>();
}