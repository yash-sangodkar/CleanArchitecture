namespace TeknorixJobs.Application.DTOs.Job;

public record UpdateJobDto(
    int Id,
    string Title,
    string Description,
    int LocationId,
    int DepartmentId,
    DateTime ClosingDate);

