using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobPortal.Application.Abstraction.Services;
using JobPortal.Application.DTOs.Department;

namespace JobPortal.API.Controllers;

[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;
    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_departmentService.GetAllDepartments());
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _departmentService.GetDepartment(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateDepartmentDto request)
    {
        var department = await _departmentService.CreateDepartment(request);
        var url = Url.Action("Get", "Department", new { id = department.Id }, Request.Scheme);

        return Ok(url);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateDepartmentDto request)
    {
        await _departmentService.UpdateDepartment(request);
        return Ok();
    }
}
