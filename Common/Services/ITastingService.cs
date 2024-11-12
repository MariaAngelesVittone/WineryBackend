using Data.DTO_s;
using Data.Entities;

namespace Common.Services;

public interface ITastingService
{
    void AddTasting(TastingForCreationDTO tastingDto);
    void AddGuests(int tastingId, List<string> newGuests);
    List<Tasting> GetUpcomingTastings();
}