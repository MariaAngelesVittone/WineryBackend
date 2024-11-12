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
                throw new InvalidOperationException("El inventario de vinos está vacío."); //
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
                throw new InvalidOperationException("El vino que quieres agregar ya se encuentra en el inventario."); //
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
}