using Data.Entities;

namespace Data.Repositories;

public class WineRepository : IWineRepository
{
    private readonly WineryContext _context;

    public WineRepository(WineryContext context)
    {
        _context = context;
    }
    public List<Wine> GetWines()
    {
        return _context.Wines.ToList();
    }

    public void AddWine(Wine wine)
    {
        _context.Wines.Add(wine);
        _context.SaveChanges();
    }

    public List<Wine> GetWinesByIds(List<int> wineIds)
    {
        return _context.Wines.Where(wine => wineIds.Contains(wine.Id)).ToList();
    }

    public List<Wine> GetWinesByVariety(string variety)
    {
        return _context.Wines.Where(w => w.Variety == variety).ToList();
    }

    public void UpdateStockById(int wineId, int newStock)
    {
        var wine = _context.Wines.FirstOrDefault(w => w.Id == wineId);

        if (wine == null)
        {
            throw new InvalidOperationException("The specified wine does not exist.");
        }

        wine.Stock = newStock;

        _context.SaveChanges();
    }
}