using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Api.UnitTests;


public class BabyDevRepositoryTests
{
    private readonly IConfiguration _configuration;

    public BabyDevRepositoryTests()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json", 
                optional: false, reloadOnChange: true);
        _configuration = builder.Build();
    }
    
    public void InsertBabyDevForecast(BabyDevForecast forecast)
    {
        var connectionString = _configuration["connectionString"];
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = @"
                INSERT INTO BabyDevForecasts (Name, AgeRangeStart, AgeRangeEnd, Description)
                VALUES (@Name, @AgeRangeStart, @AgeRangeEnd, @Description)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", forecast.Name);
                command.Parameters.AddWithValue("@AgeRangeStart", forecast.AgeRangeStart);
                command.Parameters.AddWithValue("@AgeRangeEnd", forecast.AgeRangeEnd);
                command.Parameters.AddWithValue("@Description", forecast.Description);
              //  command.Parameters.AddWithValue("@Milestones", JsonSerializer.Serialize(forecast.Milestones));

                command.ExecuteNonQuery();
            }
        }
    }

    [Fact]
    public void CreateBabyDevForecast()
    {
        InsertBabyDevForecast(new BabyDevForecast()
        {
            Name = "Baby Dev Forecast",
            AgeRangeStart = 0,
            AgeRangeEnd = 6,
             Description = "Baby Dev Forecast",
             
        });
    }

}