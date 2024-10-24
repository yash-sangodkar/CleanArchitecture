namespace JobPortal.Application.DTOs.Job;

public record JobSearchQueryDto(
    string Q,
    int PageNo,
    int PageSize,
    int? LocationId,
    int? DepartmentId);
