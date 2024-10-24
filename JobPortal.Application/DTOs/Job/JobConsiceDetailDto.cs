namespace TeknorixJobs.Application.DTOs.Job;

public record JobConsiceDetailDto(
    int Id,
    string Code,
    string Title,
    string Location,
    string Department,
    DateTime PostedDate,
    DateTime ClosingDate);
