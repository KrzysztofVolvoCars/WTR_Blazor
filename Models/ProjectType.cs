using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models;

public class ProjectType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsActive { get; set; } =true;

    public int Order { get; set; } 

    public string Color { get; set; } = "#000000";

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

