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
    

    [Fact]
    public void GetBabyDevForecast()
    {
        var connectionString = "Server=tcp:babydev.database.windows.net,1433;Initial Catalog=BabyDevForecast;Persist Security Info=False;User ID=francis;Password=ju4Laque!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        try
        {
            // Table would be created ahead of time in production
            using var conn = new SqlConnection(connectionString);
            conn.Open();

       
            
            // var command = new SqlCommand(
            //     "CREATE TABLE BabyDevForecasts (ID int NOT NULL PRIMARY KEY IDENTITY," +
            //     "Name nvarchar(255) NOT NULL," + 
            //     "AgeRangeStart INT NOT NULL," +
            //     "AgeRangeEnd INT NOT NULL," +
            //     "Description NVARCHAR(MAX));",
            //     conn);
            // using SqlDataReader reader = command.ExecuteReader();
            
            var mcommand = new SqlCommand(
                "CREATE TABLE Milestones (ID int PRIMARY KEY IDENTITY(1,1)," +
                "ForecastId INT NOT NULL," +
                "Milestone NVARCHAR(255)," +
                "FOREIGN KEY (ForecastId) REFERENCES BabyDevForecasts(Id));",
                conn);
            using SqlDataReader reader = mcommand.ExecuteReader();
        }
        catch (Exception e)
        {
            // Table may already exist
            Console.WriteLine(e.Message);
        }
    }
}