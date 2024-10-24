﻿namespace TeknorixJobs.Domain.Models;

public class Location
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int Zip { get; set; }
}
