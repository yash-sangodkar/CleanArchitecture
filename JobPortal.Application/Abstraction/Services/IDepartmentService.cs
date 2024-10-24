using JobPortal.Application.DTOs.Department;
using JobPortal.Domain.Models;

namespace JobPortal.Application.Abstraction.Services;

public interface IDepartmentService
{
    Task<Department> CreateDepartment(CreateDepartmentDto department);
    Task UpdateDepartment(UpdateDepartmentDto updateDepartment);
    List<Department> GetAllDepartments();
    Task<Department> GetDepartment(int Id);
}
