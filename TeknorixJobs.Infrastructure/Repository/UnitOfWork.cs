using TeknorixJobs.Application.Abstraction.Repository;

namespace TeknorixJobs.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly JobDbContext _context;
    public UnitOfWork(JobDbContext context)
    {
        _context = context;
        Init();
    }
    public IJobRepository Jobs { get; private set; }
    public ILocationRepository Locations { get; private set; }
    public IDepartmentRepository Departments  { get; private set; }

    public void Dispose()
    {
        _context.Dispose();
    }

    private void Init()
    {
        Jobs = new JobRepository(_context);
        Locations = new LocationRepository(_context);
        Departments = new DepartmentRepository(_context);
    }
}
