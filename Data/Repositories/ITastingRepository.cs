using Data.Entities;

namespace Data.Repositories;

public interface ITastingRepository
{
    void AddTasting(Tasting tasting);
    List<Tasting> GetTastings();
    void UpdateGuests(int tastingId, List<string> newGuests);
    List<Tasting> GetUpcomingTastings();
}