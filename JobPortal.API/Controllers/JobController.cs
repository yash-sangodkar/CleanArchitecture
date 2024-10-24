using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeknorixJobs.Application.Abstraction.Services;
using TeknorixJobs.Application.DTOs.Job;

namespace TeknorixJobs.API.Controllers;

[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class JobController : Controller
{
    private readonly IJobService _jobService;
    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateJobDto request)
    {
        var job = await _jobService.CreateJob(request);
        var url = Url.Action("Get", "Job", new { id = job.Id }, Request.Scheme);

        return Ok(url);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateJobDto request)
    {
        await _jobService.UpdateJob(request);
        return Ok();
    }

    [HttpPost]
    [Route("list")]
    public async Task<IActionResult> ListJobs(JobSearchQueryDto request)
    {
        return Ok(await _jobService.SearchJobs(request));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _jobService.GetJobById(id));
    }

}
