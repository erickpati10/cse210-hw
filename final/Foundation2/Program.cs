using System;

class Employee
{
    private string name;
    private int employeeId;
    private decimal hourlyRate;
    private int hoursWorked;

    public Employee(string name, int employeeId, decimal hourlyRate)
    {
        this.name = name;
        this.employeeId = employeeId;
        this.hourlyRate = hourlyRate;
        hoursWorked = 0;
    }

    public string Name { get { return name; } }
    public int EmployeeId { get { return employeeId; } }

    public void SetHoursWorked(int hours)
    {
        hoursWorked = hours;
    }

    public decimal CalculateSalary()
    {
        return hourlyRate * hoursWorked;
    }
}

class PayrollSystem
{
    public void ProcessPayment(Employee employee)
    {
        decimal salary = employee.CalculateSalary();
        Console.WriteLine($"Processing payment for {employee.Name} - Amount: ${salary}");
    }
}

class Program
{
    static void Main()
    {
        Employee employee1 = new Employee("John", 1001, 15.50M);
        employee1.SetHoursWorked(40);

        Employee employee2 = new Employee("Alice", 1002, 18.75M);
        employee2.SetHoursWorked(45);

        PayrollSystem payrollSystem = new PayrollSystem();
        payrollSystem.ProcessPayment(employee1);
        payrollSystem.ProcessPayment(employee2);
    }
}
