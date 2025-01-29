namespace WTR_Blazor.Models;

public class Tooltree
{
    public int Id { get; set; }
    public string PLCStationEquipment { get; set; } = string.Empty;
    public string MachineNumber { get; set; } = string.Empty;
    public string PLC { get; set; } = string.Empty;
    public string Station { get; set; } = string.Empty;
    public string AssetCode { get; set; } = string.Empty;
    public string ToolNumber { get; set; } = string.Empty;
    public int ChangeTypeId { get; set; }
    public ChangeType ChangeType { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AssetNumber { get; set; } = string.Empty;
    public string CommentLinebuilder { get; set; } = string.Empty;
    public string CommentVolvo { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Id: {Id}, PLCStationEquipment: {PLCStationEquipment}, MachineNumber: {MachineNumber}, PLC: {PLC}, " +
               $"Station: {Station}, AssetCode: {AssetCode}, ToolNumber: {ToolNumber}, ChangeType: {ChangeType}, " +
               $"Description: {Description}, AssetNumber: {AssetNumber}, CommentLinebuilder: {CommentLinebuilder}, " +
               $"CommentVolvo: {CommentVolvo}";
    }
}
