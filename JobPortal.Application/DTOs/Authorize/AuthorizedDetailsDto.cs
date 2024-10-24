namespace TeknorixJobs.Application.DTOs.Authorize;

public record AuthorizedDetailsDto(
    string ClientAppId,
    string ClientSecret);