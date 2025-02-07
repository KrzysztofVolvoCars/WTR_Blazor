using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models.TooltreeModels;

public class Tooltree
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  int Id { get; set; }

    [Required]
    public required int ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;
    public virtual ICollection<TooltreeData> TooltreeDatas { get; set; } = new List<TooltreeData>();
    public virtual ICollection<TooltreeFile> TooltreeFiles { get; set; } = new List<TooltreeFile>();

    public bool IsDone { get; set; } = false;
}


