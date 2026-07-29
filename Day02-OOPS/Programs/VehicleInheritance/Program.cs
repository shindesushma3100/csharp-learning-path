abstract class Vehicle
{
    public string Brand;
    public int Year;

    public Vehicle(string brand, int year)
    {
        Brand = brand;
        Year = year;
    }

    public abstract void StartEngine(); // every vehicle must define this differently

    public void DisplayInfo() => Console.WriteLine($"{Year} {Brand}");
}

class Car : Vehicle
{
    public int NumberOfDoors;

    public Car(string brand, int year, int doors) : base(brand, year)
    {
        NumberOfDoors = doors;
    }

    public override void StartEngine() => Console.WriteLine($"{Brand} car engine starts with a key turn.");
}

class Motorcycle : Vehicle
{
    public bool HasSidecar;

    public Motorcycle(string brand, int year, bool hasSidecar) : base(brand, year)
    {
        HasSidecar = hasSidecar;
    }

    public override void StartEngine() => Console.WriteLine($"{Brand} motorcycle engine starts with a kick or button.");
}

class ElectricCar : Car
{
    public int BatteryRangeKm;

    public ElectricCar(string brand, int year, int doors, int batteryRange) : base(brand, year, doors)
    {
        BatteryRangeKm = batteryRange;
    }

    public override void StartEngine() => Console.WriteLine($"{Brand} electric car starts silently at the push of a button.");
}

class Program
{
    static void Main()
    {
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car("Toyota", 2022, 4),
            new Motorcycle("Harley-Davidson", 2021, false),
            new ElectricCar("Tesla", 2023, 4, 400)
        };

        foreach (Vehicle v in vehicles)
        {
            v.DisplayInfo();
            v.StartEngine(); // runtime polymorphism - each calls its own version
            Console.WriteLine();
        }
    }
}