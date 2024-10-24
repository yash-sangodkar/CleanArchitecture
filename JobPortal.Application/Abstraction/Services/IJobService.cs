using JobPortal.Application.DTOs.Job;
using JobPortal.Domain.Models;

namespace JobPortal.Application.Abstraction.Services;

public interface IJobService
{
    Task<Job> CreateJob(CreateJobDto job);
    Task UpdateJob(UpdateJobDto job);
    Task<JobListDto> SearchJobs(JobSearchQueryDto query);
    Task<JobCompleteDetailDto> GetJobById(int jobId);
}
