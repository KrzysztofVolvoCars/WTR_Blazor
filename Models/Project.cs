using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WTR_Blazor.Models;

public class Project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string ECNumber { get; set; }
    [Required]
    public string ProjectName { get; set; }
    public string? PowerBI_URL { get; set; }
    public int? EngineerId { get; set; }
    public virtual Employee? Engineer { get; set; }
    public int? SupplierId { get; set; }
    public virtual Company? Supplier { get; set; }
    public int? ProjectPhaseId { get; set; }
    public virtual ProjectPhase? ProjectPhase { get; set; }
    public int? ProjectTypeId { get; set; }
    public virtual ProjectType? ProjectType { get; set; }
    public int? RMResponsibleId { get; set; }
    public virtual Employee? RMResponsible { get; set; }
    public virtual Tooltree? Tooltree { get; set; } = new();
    public virtual List<TooltreeFile> TooltreeFiles { get; set; } = new();
    public DateTime? StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? Installation { get; set; }
    public DateTime? SOP { get; set; }

}