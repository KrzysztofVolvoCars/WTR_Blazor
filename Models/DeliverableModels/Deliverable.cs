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

    public virtual Project Project { get; set; } = null!;
    public virtual ICollection<DeliverableQuestionGroup> QuestionGroups { get; set; } = new List<DeliverableQuestionGroup>();
}



