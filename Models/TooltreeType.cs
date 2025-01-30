using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models;

public class TooltreeType
{
    public int Id { get; set; }
    [Required]
    public string Code { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}

