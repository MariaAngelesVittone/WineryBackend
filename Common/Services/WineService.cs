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
                throw new InvalidOperationException("El inventario de vinos está vacío.");
            }

            return wines;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ocurrió un error al consultar el inventario de vinos.", ex);
        }
    }

    public void AddWine(WineForCreationDTO wineDTO)
    {
        try
        {
            List<Wine> inventory = _wineRepository.GetWines();

            if (inventory.Any(x => x.Name.Equals(wineDTO.Name, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new InvalidOperationException("El vino que quieres agregar ya se encuentra en el inventario.");
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
            throw new InvalidOperationException("Ocurrió un error al agregar un vino al inventario.", ex);
        }
    }

    public List<Wine> GetWinesByVariety(string variety)
    {
        try
        {
            if (string.IsNullOrEmpty(variety))
            {
                throw new InvalidOperationException("Debe indicar la variedad del vino.");
            }

            var wines = _wineRepository.GetWinesByVariety(variety);

            if (wines.Count == 0)
            {
                throw new InvalidOperationException("No se encuentra en el inventario un vino de esa variedad.");
            }

            return wines;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ocurrió un error al consultar el vino.", ex);
        }
    }

    public void UpdateStockById(int wineId, int newStock)
    {
        try
        {
            if (newStock < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo.");
            }

            _wineRepository.UpdateStockById(wineId, newStock);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ocurrió un error al actualizar el stock del vino.", ex);
        }
    }
}