using TeknorixJobs.Application.DTOs.Department;
using TeknorixJobs.Domain.Models;

namespace TeknorixJobs.Application.Abstraction.Services;

public interface IDepartmentService
{
    Task<Department> CreateDepartment(CreateDepartmentDto department);
    Task UpdateDepartment(UpdateDepartmentDto updateDepartment);
    List<Department> GetAllDepartments();
    Task<Department> GetDepartment(int Id);
}
