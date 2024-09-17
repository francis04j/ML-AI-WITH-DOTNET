using System.Text;
using WebApplication1.BabyDev;
using Moq;
using Shouldly;
namespace BabyDev.UnitTests;


public class BabyDevRangeTests
{
    [Fact]
    public void GetBabyDevByAgeRange()
    {
        //given
        int ageRangeStart = 0;
        int ageRangeEnd = 2;

        var expectBabyRange1 = new BabyDevForecast("Newborn sleep", 0, 2, "Sleep in short periods of 2-4 hours with a total of 14 - 17 hours a day", null);
        var expectBabyRange2 = new BabyDevForecast("Newborn feeding", 0, 2, "Breastfeeding or formula feeding is crucial for a newborn's nutrition. They may feed 2 -4 hours", null);
        var expectBabyRange3 = new BabyDevForecast("Newborn feeding", 3, 6, "Can eat solid. They may feed 3 -6 hours", null);
        
        IBabyDevService babyDevService = new Mock<IBabyDevService>().Object;
        //when -- i call service and service call an external service
        IEnumerable<BabyDevForecast> devs = babyDevService.GetBabyDev(ageRangeStart, ageRangeEnd);
        //then -- the expected series of text from service matches the expected text
        devs.Count().ShouldBe(2);
        devs.First().ShouldBe(expectBabyRange1);
        devs.ElementAt(1).ShouldBe(expectBabyRange2);
    }
    
    [Fact]
    public void GetBabyDevByAgeRangeByApi()
    {
        //given
        int ageRangeStart = 0;
        int ageRangeEnd = 2;
        
        var expectBabyRange1 = new BabyDevForecast("Newborn sleep", 0, 2, "Sleep in short periods of 2-4 hours with a total of 14 - 17 hours a day", null);
        
        //when -- i call service and service call an external service
        IBabyDevService babyDevService = new Mock<IBabyDevService>().Object;

        IEnumerable<BabyDevForecast> devs = babyDevService.GetBabyDev(ageRangeStart, ageRangeEnd);
        
        //then -- the expected series of text from service matches the expected text
        
    }
    
    [Fact]
    public void RomanNumeralConverter()
    {
       //Repeat string
       string input = "hello";
       string expected = "hellohellohello";
       int times = 3;
       
       StringBuilder builder = new StringBuilder();
       for (int i = 0; i < times; i++)
       {
           builder.Append(input);
       }
       
       Assert.Equal(expected, builder.ToString());
    }
}