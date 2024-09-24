using Api.Entities;
using Api.Models;

namespace Api.Interfaces;

public class BabyDevDBClient : IBabyDevDBClient
{
    private readonly ILogger<BabyDevDBClient> logger;
    
    public IQueryable<BabyDevForecast> GetBabyDev(int ageRangeStart, int ageRangeEnd)
    {
        // let connectionString = "DefaultEndpointsProtocol=https;AccountName=babyforecast;AccountKey=bKBzZBfK7wRF3nYW9stGuiudNNW9ymsS5Skm32gFk04dwo4Sarqqswu61e8hIgBPyDGdyAgrHf6tACDbqh5dNw==;TableEndpoint=https://babyforecast.table.cosmos.azure.com:443/;";
        // CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
        // CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

        throw new NotImplementedException();
    }
}