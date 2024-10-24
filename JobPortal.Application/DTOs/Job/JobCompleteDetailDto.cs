using JobPortal.Domain.Models;

namespace JobPortal.Application.DTOs.Job;

public record JobCompleteDetailDto(
    int Id,
    string Code,
    string Description,
    Domain.Models.Location Location,
    Domain.Models.Department Department,
    DateTime PostedDate,
    DateTime ClosingDate);
