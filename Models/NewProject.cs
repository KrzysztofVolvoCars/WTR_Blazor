namespace WTR_Blazor.Models;

public class NewProject
{
    public int Id { get; set; }
    public string ECNumber { get; set; }
    public string ProjectName { get; set; }

    public int? EngineerId { get; set; }  // Zmiana na int?
    public Employee? Engineer { get; set; }

    public int? SupplierId { get; set; }
    public Company? Supplier { get; set; }

    public int? RMResponsibleId { get; set; }  // Zmiana na int?
    public Employee? RMResponsible { get; set; }

    public ProjectType Type { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? Installation { get; set; }
    public DateTime? SOP { get; set; }
}
