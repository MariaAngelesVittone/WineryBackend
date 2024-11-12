namespace Data.Entities;

public class Wine
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Variety { get; set; }
    public required int Year { get; set; }
    public required string Region { get; set; }
    public List<Tasting> Tastings { get; set; } = new List<Tasting>();

    private int _stock;

    public int Stock
    {
        get => _stock;
        set
        {
            if (value < 0) throw new ArgumentException("El stock no puede ser negativo.");
            _stock = value;
        }
    }

    public void AddStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0.");
        Stock += amount;
    }

    public void RemoveStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("La cantidad a reducir debe ser mayor a 0.");
        if (Stock - amount < 0) throw new InvalidOperationException("No hay suficiente stock disponible.");
        Stock -= amount;
    }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}