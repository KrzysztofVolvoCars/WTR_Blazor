using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WTR_Blazor.Models;

public class Company
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public byte[]? LogoData { get; set; }
   // public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    [DefaultValue(true)]
    public bool IsActive { get; set; } = true;
}