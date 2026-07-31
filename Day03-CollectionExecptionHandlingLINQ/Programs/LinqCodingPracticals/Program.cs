using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design.Serialization;

class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public double Salary;
    public Employee(int id,string name,string department,double salary)
    {
        Id = id;
        Name = name;
        Department = department;
        Salary = salary;
    }
}

class Customer
{
    public int Id;
    public string Name;
    public Customer(int id,string name)
    {
        Id = id;
        Name = name;
    }
}

class Order
{
    public int OrderId;
    public int CustomerId;
    public string Product;
    public Order(int orderId,int customerId,string product)
    {
        OrderId = orderId;
        CustomerId = customerId;
        Product = product;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees =new List<Employee>
        {
            new Employee(1,"Sushma","IT",1200000),
            new Employee(2,"Jyoti","IT",75000),
            new Employee(3,"Ajit","Grphic Designer",90000),
            new Employee(4,"Lalita","Sales",75000),
        };

        Console.WriteLine(" -- 1. Employee List Queries: Name of IT department -- ");
        var itNames = employees.Where(e => e.Department =="IT").Select(e =>e.Name);
        Console.WriteLine(string.Join(", ", itNames));

        Console.WriteLine("\n -- 2. Department wise Salary (total per department) --");
        var deptSalary = employees
            .GroupBy(e=>e.Department)
            .Select(g=> new {Department = g.Key, TotalSalary = g.Sum(e => e.Salary)});
        foreach(var d in deptSalary)
          Console.WriteLine($"{d.Department}: {d.TotalSalary}");

        Console.WriteLine("\n -- 3.Highest Salary --");
        var highest = employees.OrderByDescending(e => e.Salary).First();
        Console.WriteLine($"{highest.Name}: {highest.Salary}");

        Console.WriteLine("\n-- 4. Second Highest Salary --");
        var secondHighest = employees .Select(e=> e.Salary).Distinct()
        .OrderByDescending(s=>s)
        .Skip(1)
        .First();
        Console.WriteLine(secondHighest);

        Console.WriteLine("\n -- 5. Group Employee (names per department) --");
        var grouped = employees.GroupBy(e=> e.Department);
        foreach(var g in grouped)
        {
            Console.WriteLine($"{g.Key}:{string.Join(", ",g.Select(e=> e.Name))}");
        
        }

        Console.WriteLine("\n 6. Remove Duplicate (Unique Salary Values) --");
        var uniqueSalaries = employees.Select(e => e.Salary).Distinct();
        Console.WriteLine(string.Join(", ", uniqueSalaries));

        Console.WriteLine("\n -- 7. Join Customer Order --");

        List<Customer> customers = new List<Customer>
        {
            new Customer(1, "Sushma"),
            new Customer(2, "Vikram"),
            new Customer(3, "Anjali"), // has no orders - for left join demo
        };

        List<Order> orders =new List<Order>
        {
            new Order(101,1,"Laptop"),
            new Order(102,1,"Mouse"),
            new Order(103,2,"Keyboard"),
        };

        Console.WriteLine("Inner Join (only customers WITH orders): ");
        var innerJoin = customers.Join
        (   
            orders,
            c =>c.Id,
            o => o.CustomerId,
            (c, o) => new {c.Name, o.Product}

        );
        foreach(var item in innerJoin)
        Console.WriteLine($"{item.Name} ordered {item.Product}");

        Console.Write("\n Left Join (All customers, even with no orders):");
        var leftJoin = customers.GroupJoin(
            orders,
            c=>c.Id,
            o=>o.CustomerId,
            (c,orderGroup) => new {c.Name, Orders = orderGroup}
        );

        foreach(var item in leftJoin)
        {
            if (item.Orders.Any())
            {
                foreach(var o in item.Orders)
                 Console.WriteLine($"{item.Name} ordered {o.Product}");
            }
            else
            {
                Console.WriteLine($"{item.Name} has no orders");
            }
        }

    }
}