using TeknorixJobs.Application.Abstraction.Repository;
using TeknorixJobs.Domain.Models;

namespace TeknorixJobs.Infrastructure.Repository;

public class LocationRepository : Repository<Location> , ILocationRepository
{
    public LocationRepository(JobDbContext dbContext): base(dbContext)
    {
        
    }
}
