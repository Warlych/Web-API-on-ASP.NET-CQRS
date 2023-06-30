namespace Airline.Application.Common.Expections;

public class EditException : Exception
{
    public EditException(string msg) : base($"Entity cannot be edit, reason: {msg}") {}
}