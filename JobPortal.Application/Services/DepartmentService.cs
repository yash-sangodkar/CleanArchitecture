using TeknorixJobs.Application.Abstraction.Repository;
using TeknorixJobs.Application.Abstraction.Services;
using TeknorixJobs.Application.DTOs.Department;
using TeknorixJobs.Domain.Models;

namespace TeknorixJobs.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    public DepartmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Department> CreateDepartment(CreateDepartmentDto department)
    {
        Department newDepartment = new Department()
        {
            Title = department.Title,
        };
        
        return await _unitOfWork.Departments.CreateAsync(newDepartment);
    }

    public List<Department> GetAllDepartments()
    {
        return _unitOfWork.Departments.GetAll().ToList();
    }

    public async Task<Department> GetDepartment(int Id)
    {
        return await _unitOfWork.Departments.SingleOrDefaultAsync(d => d.Id == Id);
    }

    public async Task UpdateDepartment(UpdateDepartmentDto updateDepartment)
    {
        var department = await _unitOfWork.Departments.SingleOrDefaultAsync(d => d.Id == updateDepartment.Id);

        if (department == null)
            throw new Exception($"Location not found for the given LocationId:{updateDepartment.Id}");

        department.Title = updateDepartment.Title;

        await _unitOfWork.Departments.UpdateAsync(department);

    }
}
