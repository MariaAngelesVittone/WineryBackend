using Data.Entities;

namespace Data.Repositories;

public class TastingRepository : ITastingRepository
{
    private readonly WineryContext _context;

    public TastingRepository(WineryContext context)
    {
        _context = context;
    }

    public List<Tasting> GetTastings()
    {
        return _context.Tastings.ToList();
    }

    public void AddTasting(Tasting tasting)
    {
        _context.Tastings.Add(tasting);

        _context.SaveChanges();
    }

    public void UpdateGuests(int tastingId, List<string> newGuests)
    {
        var tasting = _context.Tastings.FirstOrDefault(t => t.Id == tastingId);
        if (tasting != null)
        {
            tasting.Guests.AddRange(newGuests);
            _context.SaveChanges();
        }
    }

    public List<Tasting> GetUpcomingTastings()
    {
        return _context.Tastings.Where(t => t.Date > DateTime.Today).ToList();
    }
}