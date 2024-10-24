namespace JobPortal.Application.DTOs.Location;

public record CreateLocationDto(
    string Title,
    string City,
    string State,
    string Country,
    int Zip);
