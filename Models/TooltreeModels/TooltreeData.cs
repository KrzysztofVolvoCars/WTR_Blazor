using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WTR_Blazor.Components.Pages;

namespace WTR_Blazor.Models.TooltreeModels;

public class TooltreeData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string PlcStationEquipment { get; set; }

    [Required]
    [MaxLength(50)]
    public required string MachineNumber { get; set; } 
    
    [Required]
    [MaxLength(50)]
    public required string Plc { get; set; }

    [MaxLength(50)]
    public string? Station { get; set; }

    [Required]
    [MaxLength(50)]
    public required string AssetCode { get; set; }

    [Required]
    [MaxLength(50)]
    public required string ToolNumber { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(50)]
    public required string AssetNumber { get; set; }

    [MaxLength(500)]
    public string? CommentLinebuilder { get; set; }

    [MaxLength(500)]
    public string? CommentVolvo { get; set; }

    public int Status { get; set; } = 0;

   
    public int? TypeId { get; set; }


    public int? TooltreeId { get; set; }

    public virtual TooltreeType Type { get; set; } = null!;
    public virtual Tooltree Tooltree { get; set; } = null!;
}


