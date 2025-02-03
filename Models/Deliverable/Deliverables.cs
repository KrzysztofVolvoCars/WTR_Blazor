using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WTR_Blazor.Models.Tooltree;

namespace WTR_Blazor.Models.Deliverable;

public class Deliverables
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }
    
    public virtual List<DeliverablesTooltree> DeliverablesTooltree { get; set; } = new();
    public virtual List<DeliverablesQuestionGroup> DeliverablesQuestionGroup { get; set; } = new();

    public int Progress { get; set; } = 0;
    public bool IsDone { get; set; } = false;
}



