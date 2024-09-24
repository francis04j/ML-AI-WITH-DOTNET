using Api.Entities;
using Api.Interfaces;
using Api.Models;

namespace Api.Services;

public class BabyDevService: IBabyDevService
{
    private readonly IBabyDevDBClient dbClient;
    //TODO: to enforce maximum age of 24 months and minimum age of zero
    public BabyDevService(IBabyDevDBClient apiClient)
    {
        this.dbClient = dbClient;
    }

    public Task<IEnumerable<BabyDevForecast>> GetBabyDev(int ageRangeStart, int ageRangeEnd)
    {
        var expectBabyRange1 = new BabyDevForecast("Newborn sleep", 0, 2, "Sleep in short periods of 2-4 hours with a total of 14 - 17 hours a day", null);
        var expectBabyRange2 = new BabyDevForecast("Newborn feeding", 0, 2, "Breastfeeding or formula feeding is crucial for a newborn's nutrition. They may feed 2 -4 hours", null);
        var expectBabyRange3 = new BabyDevForecast("Newborn feeding", 3, 6, "Can eat solid. They may feed 3 -6 hours", null);

        var forecasts = new List<BabyDevForecast>() { expectBabyRange1, expectBabyRange2, expectBabyRange3 };
        var results = forecasts.FindAll(x => x.AgeRangeStart >= ageRangeStart && x.AgeRangeEnd <= ageRangeEnd);

        return Task.FromResult<IEnumerable<BabyDevForecast>>(results);
    }
}
