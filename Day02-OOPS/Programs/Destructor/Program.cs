
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

class Employee
{
    public string Name;
    public Employee(string name)
    {
        Name=name;
        Console.WriteLine($"{Name} object created");
    }
    ~Employee() //destructor
    {
        Console.WriteLine($"{Name} object destroyed");
    }
}

class Program
{
    static void Main()
    {
        CreateEmployee();
        Console.WriteLine("Forcing garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("End of Main");
    }
    static void CreateEmployee()
    {
        Employee e =new  Employee("Sushma");
        Console.WriteLine("Inside CreateEmployee Method");
    }
}