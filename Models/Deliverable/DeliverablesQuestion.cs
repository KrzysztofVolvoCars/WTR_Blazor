using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models.Deliverable;

public class DeliverablesQuestion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Question { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public int Order { get; set; }
    public bool IsActive { get; set; } = true;

    public int QuestionGroupId { get; set; }
    public virtual DeliverablesQuestionGroup DeliverablesQuestionGroup { get; set; }
    
    public int DeliverablesAnswerTypeId { get; set; }
    public virtual DeliverablesAnswerType DeliverablesAnswerType { get; set; }

    public DateTime? UpdatedAt { get; set; }

}


