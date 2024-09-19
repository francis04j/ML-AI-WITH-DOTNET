namespace DefaultNamespace;

public interface IBabyDevDBClient
{
    IQueryable<BabyDevForecast> GetBabyDev(int ageRangeStart, int ageRangeEnd);
}