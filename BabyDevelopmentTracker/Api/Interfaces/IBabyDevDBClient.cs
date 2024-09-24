using Api.Entities;

namespace Api.Interfaces;


public interface IBabyDevDBClient
{
    IQueryable<BabyDevForecast> GetBabyDev(int ageRangeStart, int ageRangeEnd);
}