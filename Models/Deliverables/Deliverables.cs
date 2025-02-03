using System.ComponentModel.DataAnnotations;
using WTR_Blazor.Models.Tooltree;

namespace WTR_Blazor.Models.Deliverables;

public class Deliverables
{
    [Key]
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }
    
    public virtual List<DeliverablesTooltree> DeliverablesTooltree { get; set; } = new();
    public virtual List<DeliverablesQuestionGroup> DeliverablesQuestionGroup { get; set; } = new();

    public int Progress { get; set; } = 0;
    public bool IsDone { get; set; } = false;
}
