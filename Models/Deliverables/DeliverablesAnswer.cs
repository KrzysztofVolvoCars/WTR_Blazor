using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models.Deliverables;

public class DeliverablesAnswer
{    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Answer { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public int Value { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; } = true;
}
