using TeknorixJobs.Application.Abstraction.Repository;
using TeknorixJobs.Domain.Models;

namespace TeknorixJobs.Infrastructure.Repository;

internal class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(JobDbContext dbContext) : base(dbContext)
    {
    }
}
