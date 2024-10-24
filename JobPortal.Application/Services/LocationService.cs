using TeknorixJobs.Application.Abstraction.Repository;
using TeknorixJobs.Application.Abstraction.Services;
using TeknorixJobs.Application.DTOs.Location;
using TeknorixJobs.Domain.Models;

namespace TeknorixJobs.Application.Services;

public class LocationService : ILocationService
{
    private readonly IUnitOfWork _unitOfWork;
    public LocationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Location> CreateLocation(CreateLocationDto location)
    {
        Location newLocation = new Location
        {
            Title = location.Title,
            City = location.City,
            Country = location.Country,
            State = location.State,
            Zip = location.Zip,
        };

        return await _unitOfWork.Locations.CreateAsync(newLocation);
    }

    public List<Location> GetAllLocations()
    {
        return _unitOfWork.Locations.GetAll().ToList();
    }

    public async Task<Location> GetLocation(int Id)
    {
        return await _unitOfWork.Locations.SingleOrDefaultAsync(l => l.Id == Id);
    }

    public async Task UpdateLocation(UpdateLocationDto updateLocation)
    {
        var location = await _unitOfWork.Locations.SingleOrDefaultAsync(l => l.Id == updateLocation.Id);

        if (location == null)
            throw new Exception($"Location not found for the given LocationId:{updateLocation.Id}");

        location.State = updateLocation.State;
        location.City = updateLocation.City;
        location.Title = updateLocation.Title;
        location.Zip = updateLocation.Zip;
        location.Country = updateLocation.Country;

        await _unitOfWork.Locations.UpdateAsync(location);
    }
}
