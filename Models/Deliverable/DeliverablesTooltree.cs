using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models.Deliverable;

public class DeliverablesTooltree
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string MachineNumber { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;    
    public int Order { get; set; }
    
}