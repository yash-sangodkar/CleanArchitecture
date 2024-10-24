using JobPortal.Application.Abstraction.Repository;
using JobPortal.Domain.Models;

namespace JobPortal.Infrastructure.Repository;

public class JobRepository : Repository<Job>, IJobRepository
{
    public JobRepository(JobDbContext dbContext) : base(dbContext)
    {
        
    }
}
