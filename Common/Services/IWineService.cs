using Data.DTO_s;
using Data.Entities;

namespace Common.Services;

public interface IWineService
{
    List<Wine> GetWines();
    void AddWine(WineForCreationDTO wineDTO);
    List<Wine> GetWinesByVariety(string variety);
    void UpdateStockById(int wineId, int newStock);
}