using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;

namespace WTR_Blazor.Models.Deliverable;

public class DeliverablesQuestionGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string GroupName { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public int Order { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual List<DeliverablesQuestion> Question { get; set; } = new();
}