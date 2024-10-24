using JobPortal.Application.Abstraction.Repository;
using JobPortal.Domain.Models;

namespace JobPortal.Infrastructure.Repository;

internal class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(JobDbContext dbContext) : base(dbContext)
    {
    }
}
