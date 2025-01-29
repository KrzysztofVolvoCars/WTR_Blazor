namespace WTR_Blazor.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] LogoData { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public bool IsActive { get; set; } = true;
}
