namespace JobPortal.Application.Abstraction.Repository;

public interface IUnitOfWork : IDisposable
{
    public IJobRepository Jobs { get; }
    public ILocationRepository Locations { get; }
    public IDepartmentRepository Departments { get; }
}
