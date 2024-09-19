namespace DefaultNamespace;

public class BabyDevDBClient : IBabyDevDBClient
{
    private readonly ILogger<BabyDevDBClient> logger;

    public IQueryable<BabyDevForecast> GetBabyDev(int ageRangeStart, int ageRangeEnd)
    {
        throw new NotImplementedException();
    }
}