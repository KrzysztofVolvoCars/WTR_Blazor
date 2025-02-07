using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WTR_Blazor.Models.TooltreeModels;

public class TooltreeFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }

    [Required]
    public required byte[] FileData { get; set; }

    [Required]
    public required long FileSize { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now.AddHours(0);

    [Required]
    [MaxLength(255)]
    public required string OrginalName { get; set; }

    [Required]
    public required int TooltreeId { get; set; }

    public virtual Tooltree Tooltree { get; set; } = null!;
}

