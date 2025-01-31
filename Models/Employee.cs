using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WTR_Blazor.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    public byte[]? PhotoData { get; set; }
    public int? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public bool IsInternal { get; set; } = true;
    public int? PositionId { get; set; }
    public virtual EmployeePosition? Position { get; set; }
    public bool IsActive { get; set; } = true;
}
