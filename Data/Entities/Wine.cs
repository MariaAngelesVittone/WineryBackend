namespace Data.Entities;

public class Wine
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Variety { get; set; }
    public int Year { get; set; }
    public required string Region { get; set; }
    public List<Tasting> Tastings { get; set; } = new List<Tasting>();

    private int _stock;

    public int Stock
    {
        get => _stock;
        set
        {
            if (value < 0) throw new ArgumentException("The stock cannot be negative.");
            _stock = value;
        }
    }

    public void AddStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("The quantity to add must be greater than 0.");
        Stock += amount;
    }

    public void RemoveStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("The quantity to reduce must be greater than 0.");
        if (Stock - amount < 0) throw new InvalidOperationException("There is not enough stock available.");
        Stock -= amount;
    }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}