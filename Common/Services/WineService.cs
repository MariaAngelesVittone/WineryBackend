using Data.DTO_s;
using Data.Entities;
using Data.Repositories;

namespace Common.Services;

public class WineService : IWineService
{
    private readonly IWineRepository _wineRepository;

    public WineService(IWineRepository wineRepository)
    {
        _wineRepository = wineRepository;
    }

    public List<Wine> GetWines()
    {
        try
        {
            var wines = _wineRepository.GetWines();

            if (wines.Count == 0)
            {
                throw new InvalidOperationException("The wine inventory is empty.");
            }

            return wines;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while fetching the wine inventory.", ex);
        }
    }

    public void AddWine(WineForCreationDTO wineDTO)
    {
        try
        {
            List<Wine> inventory = _wineRepository.GetWines();

            if (inventory.Any(x => x.Name.Equals(wineDTO.Name, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new InvalidOperationException("The wine you want to add is already in the inventory.");
            }

            Wine newWine = new Wine
            {
                Name = wineDTO.Name,
                Variety = wineDTO.Variety,
                Year = wineDTO.Year,
                Region = wineDTO.Region,
                Stock = wineDTO.Stock
            };

            newWine.Id = inventory.Count != 0 ? inventory.Max(w => w.Id) + 1 : 1;

            _wineRepository.AddWine(newWine);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while adding a wine to the inventory.", ex);
        }
    }

    public List<Wine> GetWinesByVariety(string variety)
    {
        try
        {
            if (string.IsNullOrEmpty(variety))
            {
                throw new InvalidOperationException("You must specify the wine variety.");
            }

            var wines = _wineRepository.GetWinesByVariety(variety);

            if (wines.Count == 0)
            {
                throw new InvalidOperationException("A wine of that variety is not found in the inventory.");
            }

            return wines;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while querying the wine.", ex);
        }
    }

    public void UpdateStockById(int wineId, int newStock)
    {
        try
        {
            if (newStock < 0)
            {
                throw new ArgumentException("The stock cannot be negative.");
            }

            _wineRepository.UpdateStockById(wineId, newStock);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while updating the wine stock.", ex);
        }
    }
}