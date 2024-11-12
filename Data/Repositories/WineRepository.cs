using Data.Entities;

namespace Data.Repositories;

public class WineRepository : IWineRepository
{
    public List<Wine> GetWines()
    {
        return winesInventory;
    }

    public void AddWine(Wine wine)
    {
        winesInventory.Add(wine);
    }

    public static List<Wine> winesInventory = new List<Wine>
    {
    new Wine
    {
        Id = 1,
        Name = "Don Melchor",
        Variety = "Cabernet Sauvignon",
        Year = 2018,
        Region = "Maipo Valley",
        Stock = 50
    },
    new Wine
    {
        Id = 2,
        Name = "Catena Zapata Malbec",
        Variety = "Malbec",
        Year = 2019,
        Region = "Mendoza",
        Stock = 30
    },
    new Wine
    {
        Id = 3,
        Name = "Château Margaux",
        Variety = "Merlot",
        Year = 2017,
        Region = "Bordeaux",
        Stock = 20
    },
    new Wine
    {
        Id = 4,
        Name = "La Rioja Alta Gran Reserva 904",
        Variety = "Tempranillo",
        Year = 2010,
        Region = "La Rioja",
        Stock = 10
    },
    new Wine
    {
        Id = 5,
        Name = "Vega Sicilia Único",
        Variety = "Tinto Fino",
        Year = 2011,
        Region = "Ribera del Duero",
        Stock = 5
    }
    };
}