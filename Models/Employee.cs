using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WTR_Blazor.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public required string LastName { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public required string Email { get; set; }

    [MaxLength(15)]
    [Phone]
    public string? PhoneNumber { get; set; }

    public byte[]? PhotoData { get; set; }

    public required bool IsInternal { get; set; }
    public required bool IsActive { get; set; }
 
    public int? CompanyId { get; set; } 
    public int PositionId { get; set; }

    public virtual Company? Company { get; set; } = null!;
    public virtual EmployeePosition Position { get; set; } = null!;
}
