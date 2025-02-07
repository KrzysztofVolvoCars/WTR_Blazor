using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

    public virtual DeliverableQuestionGroup QuestionGroup { get; set; } = null!;
    public virtual ICollection<DeliverableAnswerType> PossibleAnswers { get; set; } = new List<DeliverableAnswerType>();
}



