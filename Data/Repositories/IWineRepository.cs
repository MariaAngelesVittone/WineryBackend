using Data.Entities;

namespace Data.Repositories;

public interface IWineRepository
{
    List<Wine> GetWines();
    void AddWine(Wine wine);
    List<Wine> GetWinesByVariety(string variety);
    List<Wine> GetWinesByIds(List<int> wineIds);
    void UpdateStockById(int wineId, int newStock);
}