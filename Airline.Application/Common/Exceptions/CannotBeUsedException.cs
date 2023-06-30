namespace Airline.Application.Common.Expections;

public class CannotBeUsedException : Exception
{
    public CannotBeUsedException(string name, object key)
        : base($"Entity {name}, {key} cannot be used") {}
}