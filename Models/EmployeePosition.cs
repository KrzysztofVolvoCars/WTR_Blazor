using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models;

public class EmployeePosition
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
}
