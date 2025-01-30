namespace WTR_Blazor.Models;

public class Tooltree
{
    public int Id { get; set; }
    public int TooltreeDataId { get; set; }
    public virtual TooltreeData? TooltreeData { get; set; }
    public int TooltreeFileId { get; set; }
    public virtual TooltreeFile TooltreeFile { get; set; }
}
