using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models;

public class ProjectType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Order { get; set; }
    [Required]
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    [Required]
    public string Color { get; set; }
}
