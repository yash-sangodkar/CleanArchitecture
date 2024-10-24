namespace JobPortal.Application.DTOs.Job;

public record CreateJobDto(
    string Title,
    string Description,
    int LocationId,
    int DepartmentId,
    DateTime ClosingDate);
