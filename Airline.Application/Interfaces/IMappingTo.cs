using AutoMapper;

namespace Airline.Application.Interfaces;

public interface IMappingTo<T>
{
    void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}