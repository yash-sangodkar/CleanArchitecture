using JobPortal.Application.DTOs.Location;
using JobPortal.Domain.Models;

namespace JobPortal.Application.Abstraction.Services;

public interface ILocationService
{
    Task<Location> CreateLocation(CreateLocationDto location);
    Task UpdateLocation(UpdateLocationDto updateLocation);
    List<Location> GetAllLocations();
    Task<Location> GetLocation(int Id);
}
