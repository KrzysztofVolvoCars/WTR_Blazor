using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WTR_Blazor.Models.TooltreeModels;

namespace WTR_Blazor.Models.DeliverableModels;

public class DeliverableQuestionGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    [Required]
    public required int TooltreeDataId { get; set; }

    public virtual TooltreeData TooltreeData { get; set; } = null!;
    public virtual ICollection<DeliverableQuestion> Questions { get; set; } = new List<DeliverableQuestion>();
}
