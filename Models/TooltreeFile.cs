using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models;

public class TooltreeFile
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public byte[] FileData { get; set; } = Array.Empty<byte>();
    public long FileSize { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }
}