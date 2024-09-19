namespace WebApplication1.BabyDev;

public record BabyDevForecast(
    string Name,
    int AgeRangeStart,
    int AgeRangeEnd,
    string Description,
    List<string> Milestones
)
{
    public override string ToString() => $"Phase: {Name} (Age: {AgeRangeStart}-{AgeRangeEnd})";
}