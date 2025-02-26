using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace WTR_Blazor.Models.DeliverableModels;

public class Deliverable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public required int ProjectId { get; set; }

    public int Progress { get; set; } = 0;

    public bool isActive { get; set; } = false;

    public bool isDone { get; set; } = false;

    public virtual Project Project { get; set; } = null!;
    public virtual ICollection<DeliverableQuestionGroup> QuestionGroups { get; set; } = new List<DeliverableQuestionGroup>();
}



