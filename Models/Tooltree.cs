using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models;

public class Tooltree
{
    [Key]
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }

    public virtual List<TooltreeData> TooltreeData { get; set; } = new();
    public virtual List<TooltreeFile> TooltreeFiles { get; set; } = new();
    public bool IsDone { get; set; } = false;
}

