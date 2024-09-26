using WebApplication1.BabyDev;

namespace DefaultNamespace;
using Microsoft.Azure.Cosmos;

public class BabyDevDBClient : IBabyDevDBClient
{
    private readonly ILogger<BabyDevDBClient> logger;
    
    public IQueryable<BabyDevForecast> GetBabyDev(int ageRangeStart, int ageRangeEnd)
    { 
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

        throw new NotImplementedException();
    }
}