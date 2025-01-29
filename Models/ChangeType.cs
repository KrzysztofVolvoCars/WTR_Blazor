namespace WTR_Blazor.Models;

public class ChangeType
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    bool IsActive { get; set; } = true;
}

