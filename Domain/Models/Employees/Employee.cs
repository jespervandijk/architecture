namespace Domain.Models.Employees;

public class Employee
{
    public EmployeeId Id { get; set; }
    public EmployeeRole Role { get; set; }
    public EmployeeName Name { get; set; }

    public Employee(string name, EmployeeRole role)
    {
        Id = EmployeeId.Next();
        Role = role;
        Name = new EmployeeName(name);
    }
}