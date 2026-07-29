// What to watch for in the output:

// "Static constructor called" should print only once, even though Config.ConnectionString is accessed twice — this is the core static constructor rule made visible
// e3 should show the exact same Name/Salary as e2, proving the copy constructor worked

class Employee
{
    public string Name;
    public double Salary;
    //Default Constructor
    public Employee()
    {
        Console.WriteLine("Default Constructor called");
    }

//Parameterised Contructor
    public Employee(string name ,double salary)
    {
        Name=name;
        Salary=salary;
        Console.WriteLine("Parameterized Constructor called");
        
    }

    //Copy Coonstructor(Manual)
    public Employee(Employee emp)
    {
        Name=emp.Name;
        Salary=emp.Salary;
        Console.WriteLine("Copy constructor called");
    }
}

class Config
{
    public static string ConnectionString;
    static Config()
    {
        ConnectionString="Server=LocalHost;Database=TestDB";
        Console.WriteLine("Static Constructor Called");
    }
}

class Program
{
    static void Main()
    {
        Employee e1 =new  Employee(); //triggers default
        Employee e2 =new  Employee("Ajit",100000); //trigger parameterised
        Employee e3 =new  Employee(e2); //trigger copy constructor

        Console.WriteLine($"e2 ->Name{e2.Name},Salary{e2.Salary}");
        Console.WriteLine($"e3 (Copy of e2) -> Name{e3.Name},Salary{e3.Salary}");

        //Accessing static member triggers static constructor (only onec ever)
        Console.WriteLine(Config.ConnectionString);
        Console.WriteLine(Config.ConnectionString); // static constructor does NOT run again
    }
}