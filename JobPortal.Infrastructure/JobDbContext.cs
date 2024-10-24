using Microsoft.EntityFrameworkCore;
using TeknorixJobs.Domain.Models;


namespace TeknorixJobs.Infrastructure;

public class JobDbContext : DbContext 
{
    public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>()
            .HasKey(j => j.Id);

        modelBuilder.Entity<Job>()
            .HasOne<Department>()
            .WithMany()
            .HasForeignKey(j => j.DepartmentId);

        modelBuilder.Entity<Department>()
            .HasKey(d => d.Id);

        modelBuilder.Entity<Location>()
            .HasKey(l => l.Id);
    }

}
