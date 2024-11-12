using Data.Entities;

namespace Data.Repositories;

public interface IWineRepository
{
    List<Wine> GetWines();
    void AddWine(Wine wine);
}