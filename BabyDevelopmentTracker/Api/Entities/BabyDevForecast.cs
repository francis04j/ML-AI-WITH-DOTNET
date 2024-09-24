namespace Api.Entities;

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