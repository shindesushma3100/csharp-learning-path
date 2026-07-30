using System.Linq;
using System.Collections.Generic;
class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public double Salary;

    public Employee(int id ,string name,string department,double salary)
    {
        Id=id;
        Name=name;
        Department=department;
        Salary=salary;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees=new List<Employee>
        {
            new Employee(1,"Sushma","IT",60000),
            new Employee(2,"Jyoti","IT",80000),
            new Employee(3,"Dnyaneshwar","IT",90000),
            new Employee(4,"Ajit","Graphic Desinger",100000),
            new Employee(5,"Divya","Sale",50000),
            new Employee(6,"Neha","Finanace",60000),

        };

        Console.WriteLine("-- Where: employees earning >60000 --");
        var highEarners = employees.Where(e => e.Salary>60000);
        foreach(var e in highEarners) Console.WriteLine($"{e.Name} -{e.Salary}");

        Console.WriteLine("\n -- Select: just names --");
        var names=employees.Select(e=>e.Name);
        Console.WriteLine(string.Join(", ",names));

         Console.WriteLine("\n-- OrderBy: sorted by salary ascending --");
        var sorted = employees.OrderBy(e => e.Salary);
        foreach (var e in sorted) Console.WriteLine($"{e.Name} - {e.Salary}");

        Console.WriteLine("\n-- OrderByDescending: sorted by salary descending --");
        var sortedDesc = employees.OrderByDescending(e => e.Salary);
        foreach (var e in sortedDesc) Console.WriteLine($"{e.Name} - {e.Salary}");

        Console.WriteLine("\n-- Any: does anyone earn over 100000? --");
        bool anyOver100k = employees.Any(e => e.Salary > 100000);
        Console.WriteLine(anyOver100k);

        Console.WriteLine("\n-- All: does everyone earn over 40000? --");
        bool allOver40k = employees.All(e => e.Salary > 40000);
        Console.WriteLine(allOver40k);

        Console.WriteLine("\n-- First / FirstOrDefault --");
        var firstInIT = employees.First(e => e.Department == "IT");
        Console.WriteLine($"First in IT: {firstInIT.Name}");

        var firstInSales = employees.FirstOrDefault(e => e.Department == "Sales");
        Console.WriteLine($"First in Sales: {(firstInSales == null ? "None found" : firstInSales.Name)}");

        Console.WriteLine("\n-- Skip/Take (pagination): page 2, page size 2 --");
        var page2 = employees.Skip(2).Take(2);
        foreach (var e in page2) Console.WriteLine(e.Name);
    }
}