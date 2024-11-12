using Data.DTO_s;
using Data.Entities;
using Data.Repositories;

namespace Common.Services;

public class TastingService : ITastingService
{
    private readonly ITastingRepository _tastingRepository;
    private readonly IWineRepository _wineRepository;

    public TastingService(ITastingRepository tastingRepository, IWineRepository wineRepository)
    {
        _tastingRepository = tastingRepository;
        _wineRepository = wineRepository;
    }

    public void AddTasting(TastingForCreationDTO tastingDto)
    {
        try
        {
            List<Tasting> tastings = _tastingRepository.GetTastings();

            if (tastings.Any(x => x.Name.Equals(tastingDto.Name, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new InvalidOperationException("La cata ya se encuentra registrada.");
            }

            List<Wine> wines = _wineRepository.GetWinesByIds(tastingDto.WineIds);

            Tasting newTasting = new Tasting
            {
                Name = tastingDto.Name,
                Date = tastingDto.Date,
                Wines = wines,
                Guests = tastingDto.Guests
            };

            _tastingRepository.AddTasting(newTasting);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ocurrió un error al registrar la cata.", ex);
        }
    }

    public void AddGuests(int tastingId, List<string> newGuests)
    {
        _tastingRepository.UpdateGuests(tastingId, newGuests);
    }

    public List<Tasting> GetUpcomingTastings()
    {
        return _tastingRepository.GetUpcomingTastings();
    }
}