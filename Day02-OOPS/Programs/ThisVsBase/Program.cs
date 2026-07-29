class Animal
{
    public Animal()
    {
        Console.WriteLine("Animal constructor called");
    }

    public Animal(string name)
    {
        Console.WriteLine($"Animal constructor called with name: {name}");
    }

    public virtual void Sound() => Console.WriteLine("Animal makes a sound");
}

class Dog : Animal
{
    public Dog() : base() // explicitly calling base's parameterless constructor
    {
        Console.WriteLine("Dog constructor called");
    }

    public Dog(string name) : base(name) // passing along to base's parameterized constructor
    {
        Console.WriteLine($"Dog constructor called with name: {name}");
    }

    public override void Sound()
    {
        base.Sound();        // calling the base class's version first
        Console.WriteLine("Dog barks");
    }
}

class Counter
{
    public int Count;

    public Counter(int count)
    {
        this.Count = count; // 'this' disambiguates the field from the parameter
    }

    public Counter() : this(0) // 'this' calling another constructor in the SAME class
    {
        Console.WriteLine("Default Counter constructor, delegated to Counter(int)");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("-- base keyword: constructor chaining --");
        Dog d1 = new Dog();
        Console.WriteLine();
        Dog d2 = new Dog("Tommy");

        Console.WriteLine("\n-- base keyword: calling overridden base method --");
        d1.Sound(); // prints Animal's line AND Dog's line

        Console.WriteLine("\n-- this keyword: constructor chaining + field disambiguation --");
        Counter c = new Counter();
        Console.WriteLine($"Count: {c.Count}");
    }
}