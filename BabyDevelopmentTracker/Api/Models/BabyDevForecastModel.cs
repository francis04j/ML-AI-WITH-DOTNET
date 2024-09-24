namespace Api.Models;

public record BabyDevForecastModel
(
    string Name,
    int AgeRangeStart,
    int AgeRangeEnd,
    string Description,
        List<string> Milestones
);