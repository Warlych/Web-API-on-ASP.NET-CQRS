using Airline.Domain.Interfaces;

namespace Airline.Domain;
public class CrewMember : IPeople
{
    public required Guid CrewMemberId { get; set; }
    public required string FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public required double Salary { get; set; }
    public required string JobTitle { get; set; }

    public Guid? CrewId { get; set; }
    public Crew? CurrentCrew { get; set; }
}