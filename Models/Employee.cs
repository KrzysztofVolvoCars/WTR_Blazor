namespace WTR_Blazor.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PhotoData { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}
