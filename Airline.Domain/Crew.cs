namespace Airline.Domain;

public class Crew
{
    public required Guid CrewId { get; set; }
    public required string Name { get; set; }
    public List<CrewMember>? Members { get; set; }
}