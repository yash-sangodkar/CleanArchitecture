namespace JobPortal.Domain.Models;

public class Job
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public int DepartmentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ClosingDate { get; set; }
    public DateTime PostedDate { get; set; }
}
