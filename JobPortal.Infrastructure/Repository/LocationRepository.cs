using JobPortal.Application.Abstraction.Repository;
using JobPortal.Domain.Models;

namespace JobPortal.Infrastructure.Repository;

public class LocationRepository : Repository<Location> , ILocationRepository
{
    public LocationRepository(JobDbContext dbContext): base(dbContext)
    {
        
    }
}
