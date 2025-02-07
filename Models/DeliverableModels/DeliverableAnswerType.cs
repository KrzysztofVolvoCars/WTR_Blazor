using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models.DeliverableModels;

public class DeliverableAnswerType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Answer { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public required int Value { get; set; }

    public required int Order { get; set; }

    public bool IsActive { get; set; } = true;

    public virtual ICollection<DeliverableQuestion> Questions { get; set; } = new List<DeliverableQuestion>();
}

