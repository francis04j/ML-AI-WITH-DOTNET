namespace DefaultNamespace;
using Microsoft.Azure.Cosmos.Table;

public class BabyDevRepositoryTests
{
    [Fact]
    public async Task<BabyDevForecast> GetBabyDevForecast(string name)
    {
        

        let connectionString 
            = "DefaultEndpointsProtocol=https;AccountName=babyforecast;AccountKey=bKBzZBfK7wRF3nYW9stGuiudNNW9ymsS5Skm32gFk04dwo4Sarqqswu61e8hIgBPyDGdyAgrHf6tACDbqh5dNw==;TableEndpoint=https://babyforecast.table.cosmos.azure.com:443/;";
        1wqwDefaultEndpointsProtocol=https;AccountName=babyforecast;AccountKey=bKBzZBfK7wRF3nYW9stGuiudNNW9ymsS5Skm32gFk04dwo4Sarqqswu61e8hIgBPyDGdyAgrHf6tACDbqh5dNw==;TableEndpoint=https://babyforecast.table.cosmos.azure.com:443/;
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

        var query = new QueryDefinition("SELECT * FROM c WHERE c.Name = @name")
            .WithParameter("@name", name);

        var iterator = _container.GetItemQueryIterator<BabyDevForecast>(query);
        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync();
            foreach (var item in response)
            {
                return item;
            }
        }
        return null;
    }
}