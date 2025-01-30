namespace WTR_Blazor.Models;

public class ProjectType
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public string Color { get; set; }
}
