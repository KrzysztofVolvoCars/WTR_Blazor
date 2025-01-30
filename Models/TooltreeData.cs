using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models;

public class TooltreeData
{
    public int Id { get; set; }
    [Required]
    public string PLCStationEquipment { get; set; } = string.Empty;
    [Required]
    public string MachineNumber { get; set; } = string.Empty;
    [Required]
    public string PLC { get; set; } = string.Empty;
    [Required]
    public string Station { get; set; } = string.Empty;
    [Required]
    public string AssetCode { get; set; } = string.Empty;
    [Required]
    public string ToolNumber { get; set; } = string.Empty;
    public int TypeId { get; set; }
    public virtual TooltreeType Type { get; set; }
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public string AssetNumber { get; set; } = string.Empty;
    public string? CommentLinebuilder { get; set; } = string.Empty;
    public string? CommentVolvo { get; set; } = string.Empty;
}
