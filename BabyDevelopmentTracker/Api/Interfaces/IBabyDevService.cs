using Api.Entities;

namespace Api.Interfaces;

public interface IBabyDevService
{
    Task<IEnumerable<BabyDevForecast>> GetBabyDev(int ageRangeStart, int ageRangeEnd); 
}