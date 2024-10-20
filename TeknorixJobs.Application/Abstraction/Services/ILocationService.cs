using TeknorixJobs.Application.DTOs.Location;
using TeknorixJobs.Domain.Models;

namespace TeknorixJobs.Application.Abstraction.Services;

public interface ILocationService
{
    Task<Location> CreateLocation(CreateLocationDto location);
    Task UpdateLocation(UpdateLocationDto updateLocation);
    List<Location> GetAllLocations();
    Task<Location> GetLocation(int Id);
}
