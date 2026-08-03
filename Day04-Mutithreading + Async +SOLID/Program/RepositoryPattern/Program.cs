using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int  Id;
    public string Name;
    public Employee(int id ,string name)
    {
        Id = id;
        Name = name;
    }
}

//The contract - business logic depends on this not a specific implementation
interface IEmployeeRepository
{
    void Add(Employee employee);
    Employee GetById(int id);
    List<Employee> GetAll();
    void Delete(int id);
}

// One possible implementation - an in-memory "database"
class InMemoryEmployeeRepository : IEmployeeRepository
{
    private List<Employee> employees => new List<Employee>();

    public void Add(Employee employee)=> employees.Add(employee);
    public Employee GetById(int id)=> employees.FirstOrDefault(e=> e.Id == id);
    public List<Employee> GetAll() => employees;
    public void Delete(int id) => employees.RemoveAll(e=>e.Id ==id);
}

//Business logic layer - only knows about the Interface, not the implementation
class EmmployeeService
{
    private readonly IEmployeeRepository repository;
    public EmmployeeService(IEmployeeRepository repository)
    {
        this.repository = repository; // injected from outside
    }

    public void HireEmployee(int id,string name)
    {
        repository.Add(new Employee(id,name));
        Console.WriteLine($"{name} hired");
    }

    public void ShowAllEmployees()
    {
        foreach(var e in repository.GetAll())
        {
            Console.WriteLine($"{e.Id};{e.Name}");
        }
    }
}

class Program
{
    static void Main()
    {
        IEmployeeRepository repo =new InMemoryEmployeeRepository();
        EmmployeeService service = new EmmployeeService(repo); //repo injected here

        service.HireEmployee(1,"Sushma");
        service.HireEmployee(2,"Lalita");

        Console.WriteLine("\n -- All Employees --");
        service .ShowAllEmployees();
    }
}