class Animal
{
    public virtual void Sound() => Console.WriteLine("Some generic animal sound");
}

class Dog : Animal
{
    public sealed override void Sound() => Console.WriteLine("Dog barks"); // locked - can't be overridden further
}

// class Puppy : Dog
// {
//     public override void Sound() => Console.WriteLine("Puppy yips"); // this would NOT compile
// }

sealed class UtilityClass
{
    public void Helper() => Console.WriteLine("Utility method");
}

// class ExtendedUtility : UtilityClass { } // this would NOT compile - class itself is sealed

class Program
{
    static void Main()
    {
        Dog d = new Dog();
        d.Sound();

        UtilityClass util = new UtilityClass();
        util.Helper();
    }
}

// The experiment that matters here: uncomment the Puppy class — you'll get a compiler error because Dog.Sound() is sealed override, meaning no further class can override it again. Then uncomment ExtendedUtility — another compiler error, because the whole class is sealed, so nothing can inherit from it at all. Comment both back out afterward so it compiles.