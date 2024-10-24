namespace JobPortal.Application.DTOs.Location;

public record UpdateLocationDto(
    int Id,
    string Title,
    string City,
    string State,
    string Country,
    int Zip);
