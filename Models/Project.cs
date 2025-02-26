using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
using WTR_Blazor.Models.DeliverableModels; 
using WTR_Blazor.Models.TooltreeModels;

namespace WTR_Blazor.Models;

public class Project
{

    public Project()
    {
        EcNumber = string.Empty;
        ProjectName = string.Empty;
        StartDate = DateTime.Now;
        Installation = DateTime.Now.AddMonths(1);
        Sop = DateTime.Now.AddMonths(2);
        EngineerId = 0;
        RmTechnikerId = 0;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string EcNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public required string ProjectName { get; set; }

    [MaxLength(500)]
    public string? PowerBiUrl { get; set; }

    [Required]
    public required DateTime? StartDate { get; set; }

    [Required]
    public required DateTime? Installation { get; set; }

    [Required]
    public required DateTime? Sop { get; set; }

    [Required]
    public required int EngineerId { get; set; }

    [Required]
    public required int RmTechnikerId { get; set; }


    public int? SupplierId { get; set; }

  
    public int? ProjectPhaseId { get; set; }

   
    public int? ProjectTypeId { get; set; }

   
    public int? TooltreeId { get; set; }

    public virtual Employee Engineer { get; set; } = null!;
    public virtual Employee RmTechniker { get; set; } = null!;
    public virtual Company Supplier { get; set; } = null!;
    public virtual ProjectPhase ProjectPhase { get; set; } = null!;
    public virtual ProjectType ProjectType { get; set; } = null!;
    public virtual Tooltree Tooltree { get; set; } = null!;
    public virtual Deliverable Deliverable { get; set; } = null!;
}

