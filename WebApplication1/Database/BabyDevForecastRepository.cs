namespace DefaultNamespace;
using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

using WebApplication1.BabyDev;
public class BabyDevForecastRepository
{
    private readonly CosmosClient _cosmosClient;
    private readonly Container _container;
    
    public BabyDevForecastRepository(string connectionString, string databaseId, string containerId)
    {
        _cosmosClient = new CosmosClient(connectionString);
        _container = _cosmosClient.GetContainer(databaseId, containerId);
    }

    public async Task AddBabyDevForecastAsync(BabyDevForecast forecast)
    {
        var forecastDocument = new
        {
            id = Guid.NewGuid().ToString(),
            forecast.Name,
            forecast.AgeRangeStart,
            forecast.AgeRangeEnd,
            forecast.Description,
            forecast.Milestones
        };

        await _container.CreateItemAsync(forecastDocument);
    }

    public async Task<BabyDevForecast> GetBabyDevForecastAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<BabyDevForecast>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task<List<BabyDevForecast>> GetBabyDevForecastAsync(int ageStart, int ageEnd)
    {
        try
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.AgeRangeStart = @ageStart AND c.AgeRangeEnd = @ageEnd")
                .WithParameter("@ageStart", ageStart).WithParameter("@ageEnd", ageEnd);

            var iterator = _container.GetItemQueryIterator<BabyDevForecast>(query);
            var results = new List<BabyDevForecast>();
            
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                foreach (var item in response)
                {
                    results.Add(item);
                }
            }

            return results;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }
}



