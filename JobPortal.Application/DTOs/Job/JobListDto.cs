namespace JobPortal.Application.DTOs.Job;

public record JobListDto(
    int Total,
    List<JobConsiceDetailDto> Data);
