// Explaintation:Key thing to notice: emp1 and emp2 are two completely separate objects in memory, both created from the same Employee blueprint. Changing emp1.Salary has zero effect on emp2 — this is the "class is a blueprint, object is a real instance" idea made concrete.

class Employee
{
    public string Name;
    public double Salary;

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name},Salary:{Salary}");
    }

}
class Program
{
    static void Main()
    {
        Employee emp1 =new  Employee(); //object created on heap
        emp1.Name="Raj";
        emp1.Salary=50000;

        Employee emp2 = new Employee();
        emp2.Name="Ajit";
        emp2.Salary=100000;

        emp1.DisplayInfo();
        emp2.DisplayInfo();
    }
}
