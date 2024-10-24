using JobPortal.Application.Abstraction.Repository;
using JobPortal.Application.Abstraction.Services;
using JobPortal.Application.DTOs.Job;
using JobPortal.Domain.Models;

namespace JobPortal.Application.Services;

public class JobService : IJobService
{
    private readonly IUnitOfWork _unitOfWork;
    public JobService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Job> CreateJob(CreateJobDto job)
    {
        bool doesLocationExist = await _unitOfWork.Locations.ExistsAsync(l => l.Id == job.LocationId);
        bool doesDepartmentExist = await _unitOfWork.Departments.ExistsAsync(d => d.Id == job.DepartmentId);

        if (!doesLocationExist || !doesDepartmentExist)
        {
            throw new Exception("Department/Location doesn't exist for the give DepartmentId/LocationId");
        }

        Job newJob = new Job
        {
            Title = job.Title,
            DepartmentId = job.DepartmentId,
            LocationId = job.LocationId,
            Description = job.Description,
            ClosingDate = job.ClosingDate,
            PostedDate = DateTime.UtcNow
        };

        return await _unitOfWork.Jobs.CreateAsync(newJob);
    }


    public async Task<JobCompleteDetailDto> GetJobById(int jobId)
    {
        var job = await _unitOfWork.Jobs.SingleOrDefaultAsync(j => j.Id == jobId);
        if (job == null)
            throw new Exception($"No {nameof(job)} found with id {jobId}");

        var location = await _unitOfWork.Locations.SingleOrDefaultAsync(l => l.Id == job.LocationId);
        var department = await _unitOfWork.Departments.SingleOrDefaultAsync(d  => d.Id == job.DepartmentId);

        JobCompleteDetailDto jobCompleteDetail = new JobCompleteDetailDto(
            Id: job.Id,
            Code: "JOB-01",
            Description: job.Description,
            Location: location,
            Department: department,
            PostedDate: job.PostedDate,
            ClosingDate: job.ClosingDate);

        return jobCompleteDetail;
    }

    public async Task<JobListDto> SearchJobs(JobSearchQueryDto query)
    {
        var filteredJobs = await _unitOfWork.Jobs.FindAsync(j =>
                ( !string.IsNullOrEmpty(query.Q) && j.Title.Contains(query.Q) ) ||
                ( query.DepartmentId != null && j.DepartmentId == query.DepartmentId ) ||
                ( query.LocationId != null && j.LocationId == query.LocationId) 
        );

        List<JobConsiceDetailDto> jobConsiceDetails = new List<JobConsiceDetailDto>();
        if (filteredJobs != null) 
        {
            foreach (var (job, index) in filteredJobs.Select((item, index) => (item, index))) 
            {
                var location = await _unitOfWork.Locations.SingleOrDefaultAsync(l => l.Id == job.LocationId);
                var department = await _unitOfWork.Departments.SingleOrDefaultAsync(d => d.Id == job.DepartmentId);

                JobConsiceDetailDto jobConsiceDetail = new JobConsiceDetailDto(
                    Id: job.Id,
                    Code: $"JOB-{(index + 1).ToString("D2")}",
                    Title: job.Title,
                    Location: location.Title,
                    Department: department.Title,
                    PostedDate: job.PostedDate,
                    ClosingDate: job.ClosingDate);

                jobConsiceDetails.Add(jobConsiceDetail);
            }
        }

        return new JobListDto(Total: jobConsiceDetails.Count, Data: jobConsiceDetails);
    }

    public async Task UpdateJob(UpdateJobDto updatedJob)
    {
        var job = await _unitOfWork.Jobs.SingleOrDefaultAsync(j => j.Id == updatedJob.Id);
        bool doesLocationExist = await _unitOfWork.Locations.ExistsAsync(l => l.Id == updatedJob.LocationId);
        bool doesDepartmentExist = await _unitOfWork.Departments.ExistsAsync(d => d.Id == updatedJob.DepartmentId);

        if (job == null || !doesLocationExist || !doesDepartmentExist)
            throw new Exception("No job/department/location found");

        job.Title = updatedJob.Title;
        job.LocationId = updatedJob.LocationId;
        job.DepartmentId = updatedJob.DepartmentId;
        job.ClosingDate = updatedJob.ClosingDate;
        job.Description = updatedJob.Description;

        await _unitOfWork.Jobs.UpdateAsync(job);
    }
}
