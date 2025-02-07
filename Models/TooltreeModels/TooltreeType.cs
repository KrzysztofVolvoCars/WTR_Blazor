using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WTR_Blazor.Models.TooltreeModels;

public class TooltreeType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(5)]
    public required string Code { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TooltreeData> TooltreeDatas { get; set; } = new List<TooltreeData>();
}


