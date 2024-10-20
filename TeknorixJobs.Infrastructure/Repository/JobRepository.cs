using TeknorixJobs.Application.Abstraction.Repository;
using TeknorixJobs.Domain.Models;

namespace TeknorixJobs.Infrastructure.Repository;

public class JobRepository : Repository<Job>, IJobRepository
{
    public JobRepository(JobDbContext dbContext) : base(dbContext)
    {
        
    }
}
