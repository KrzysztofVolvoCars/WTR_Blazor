using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WTR_Blazor.Models;

public class TooltreeFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public byte[] FileData { get; set; } = Array.Empty<byte>();
    public long FileSize { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    [Required]
    public string OrginalName { get; set; }
    // Klucz obcy dla relacji 1:N
    public int TooltreeId { get; set; }
    public virtual Tooltree Tooltree { get; set; }
}