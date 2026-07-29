using System.Collections.Generic;

class Employee
{
    public int Id;
    public string Name;
    public double Salary;

    public Employee(int id,string name,double salary)
    {
        Id=id;
        Name=name;
        Salary=salary;
    }

    public void Display()=>Console.WriteLine($"ID: {Id},Name:{Name},Salary:{Salary}");
}

class EmployeeManager
{
    private List<Employee> employees = new List<Employee>();

    public void Create(int id ,string name,double salary)
    {
        employees.Add(new Employee(id,name,salary));
        Console.WriteLine($"Employee {name} added.");
    }

    public void ReadAll()
    {
        if(employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }
        foreach(var emp in employees)
        {
            emp.Display();
        }
    }

    public void Update(int id, string newName, double newSalary)
    {
        Employee emp = employees.Find(e => e.Id == id);
        if (emp != null)
        {
            emp.Name = newName;
            emp.Salary = newSalary;
            Console.WriteLine($"Employee {id} updated.");
        }
        else
        {
            Console.WriteLine($"Employee {id} not found.");
        }
    }

    public void Delete(int id)
    {
        Employee emp = employees.Find(e => e.Id == id);
        if (emp != null)
        {
            employees.Remove(emp);
            Console.WriteLine($"Employee {id} deleted.");
        }
        else
        {
            Console.WriteLine($"Employee {id} not found.");
        }
    }
}
class Program
{
    static void Main()
    {
        EmployeeManager manager = new EmployeeManager();

        manager.Create(1, "Raj", 50000);
        manager.Create(2, "Priya", 65000);

        Console.WriteLine("\n-- All Employees --");
        manager.ReadAll();

        Console.WriteLine("\n-- Updating Employee 1 --");
        manager.Update(1, "Raj Kumar", 55000);
        manager.ReadAll();

        Console.WriteLine("\n-- Deleting Employee 2 --");
        manager.Delete(2);
        manager.ReadAll();
    }
}