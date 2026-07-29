using System.Linq.Expressions;

class Animal
{
    public void Eat() => Console.WriteLine("Eating...");
}
class Dog : Animal
{
    public void Bark() => Console.WriteLine("Barking...");
}
class Puppy : Dog
{
    public void Whine() => Console.WriteLine("Whining...");
}
class Cat : Animal
{
    public void Meow() => Console.WriteLine("Meowing...");
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--Single Inheritance (Animal -> Dog)--");
        Dog d=new  Dog();
        d.Eat();
        d.Bark();

        Console.WriteLine("\n --Multilevel Inheritance (Anima -> Dog ->Puppy)--");
        Puppy p =new Puppy();
        p.Eat(); //inherited from Animal(grandParent)
        p.Bark(); //inherited from Dog (parent)
        p.Whine();

        Console.WriteLine("\n -- Hierarchical Inheritance (Animal ->Dog,Animal->cat)--");
        Cat c =new Cat();
        c.Eat(); //same base method ,different derived class
        c.Meow();

    }
}