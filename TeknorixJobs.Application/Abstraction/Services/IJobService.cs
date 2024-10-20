using TeknorixJobs.Application.DTOs.Job;
using TeknorixJobs.Domain.Models;

namespace TeknorixJobs.Application.Abstraction.Services;

public interface IJobService
{
    Task<Job> CreateJob(CreateJobDto job);
    Task UpdateJob(UpdateJobDto job);
    Task<JobListDto> SearchJobs(JobSearchQueryDto query);
    Task<JobCompleteDetailDto> GetJobById(int jobId);
}
