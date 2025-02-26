using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WTR_Blazor.Models.TooltreeModels;

namespace WTR_Blazor.Models.DeliverableModels;

public class DeliverableQuestion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(500)]
    public required string Question { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    [Required]
    public required int QuestionGroupId { get; set; }
    
    public int? ProjectPhaseId { get; set; }

    public virtual DeliverableQuestionGroup QuestionGroup { get; set; } = null!;
    public virtual ProjectPhase? ProjectPhase { get; set; } = null!;
    public virtual DeliverableAnswerType DeliverableAnswerType { get; set; } = null!;
}



