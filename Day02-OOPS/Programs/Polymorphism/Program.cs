//Compile-time polymorphism :Method overloading
class Calculator
{
    public int Add(int a,int b)=>a + b;
    public double Add(double a,double b)=> a + b;
    public int Add(int a ,int b,int c)=> a + b + c;
}

//Run-time polymorphism : Method Overriding
class Animal
{
    public virtual void Sound() => Console.WriteLine("Animal Makes a Sound");
}
class Dog : Animal
{
    public override void Sound() => Console.WriteLine("Dog barks");
}
// Demonstrating method HIDING (no virtual/override) for contrast
class AnimalNoVirtual
{
    public void Sound() => Console.WriteLine("AnimalNoVirtual makes a sound");
}

class DogNoOverride : AnimalNoVirtual
{
    public new void Sound() => Console.WriteLine("DogNoOverride barks");
}
class Program
{
    static void Main()
    {
        Console.WriteLine("-- Overloading (compile-time) --");
        Calculator calc = new Calculator();
        Console.WriteLine(calc.Add(2, 3));         // int version
        Console.WriteLine(calc.Add(2.5, 3.5));      // double version
        Console.WriteLine(calc.Add(1, 2, 3));       // 3-param version

        Console.WriteLine("\n-- Overriding (runtime, WITH virtual/override) --");
        Animal a = new Dog();
        a.Sound(); // "Dog barks" — decided by actual object type at runtime

        Console.WriteLine("\n-- Method HIDING (no virtual/override) --");
        AnimalNoVirtual anv = new DogNoOverride();
        anv.Sound(); // calls AnimalNoVirtual's version — decided by REFERENCE type, not object type
    }
}