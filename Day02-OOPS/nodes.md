#Day 2 OOPS
1. Class vs Object

Class — a blueprint/template. Doesn't occupy memory until instantiated.
Object — a runtime instance of a class. Occupies memory (heap).

csharp
class Employee
{
    public string Name;
    public double Salary;
    Employee emp = new Employee(); // object created on heap
    emp.Name = "Raj";
}

Interview one-liner: "A class is a logical entity, an object is a physical entity."

------------------------------------------------------------------------------------------

2. Constructors

A constructor is a special method, same name as the class, no return type, called automatically when an object is created.

Types:

a) Default Constructor — no parameters, compiler provides one if you don't write any.

C#
class Employee
{
    public Employee()  //default
    {
        Console.WriteLine("Employee cretaed);
    }
}
-----------------------------------
b) Parameterized Constructor - takes arguments to initialize fields.

C#
class Employee{
    public string Name;
    public Employee(string name)
    {
        Name = name
    }
}
----------------------------------
c) Static Constructor - initializes static members, called only onece,automatically , before the fisrtb instance is created or any static member is accessed.Cannot take parameters,cannot have access modifiers.

C# 
class Config
{
    public static string ConnectionString;
    static config()
    {
        ConnectionString = "Server=...";
        Console.WriteLine("Static constructor called);
    }
}
Interview trap: "How many times does a static constructor run?" → Exactly once per type, no matter how many objects you create.
----------------------------------

d) Copy Constructor — not built into C# like C++; you write it manually to create a new object by copying another object's values.

C#
class Employee
{
    public string Name;
    public double Salary;

    public Employee(Employee emp) // copy constructor
    {
        Name = emp.Name;
        Salary = emp.Salary;
    }
}

Employee e1 = new Employee { Name = "Raj", Salary = 50000 };
Employee e2 = new Employee(e1); // copy of e1

-----------------------------------------------
3. Destructor
Used to clean up unmanaged resources.
Same name as class, prefixed with ~, no access modifier, no parameters, cannot be overloaded.
Called automatically by the Garbage Collector — you never call it directly, and you don't know exactly when it runs.

C#
class Employee
{
    ~Employee()
    {
        Console.WriteLine("Destructor called");
    }
}

Interview trap: "Can you have multiple destructors?" → No. Only one per class, and it can't be overloaded (unlike constructors).

----------------------------------------
4. Inheritance

A class (child/derived) acquires properties and behavior of another class (parent/base). Achieved using : in C#.

C#
class Animal
{
    public void Eat() => Console.WriteLine("Eating...");
}

class Dog : Animal
{
    public void Bark() => Console.WriteLine("Barking...");
}

Dog d = new Dog();
d.Eat();  // inherited
d.Bark();

--------------------------------
Types of Inheritance in C#:

Single (A → B)
Multilevel (A → B → C)
Hierarchical (A → B, A → C)
Multiple — not supported for classes (only via interfaces, to avoid the "diamond problem")

Interview trap: "Why doesn't C# support multiple inheritance?" → Ambiguity: if two base classes have the same method, the compiler can't decide which one to call. Interfaces avoid this because they don't carry implementation (pre-C# 8; default interface methods complicate this slightly, but expect the classic answer).

-----------------------------------
5. Polymorphism

"Many forms" — same method behaves differently based on context. Two kinds:

a) Compile-time Polymorphism → Method Overloading

Same method name, different signature (parameter count/type), resolved at compile time.

C#
class Calculator
{
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;
    public int Add(int a, int b, int c) => a + b + c;
}
--------------------------------Rule: Return type alone can't differentiate overloads — only parameter list matters.

b) Run-time Polymorphism → Method Overriding

A derived class provides a specific implementation of a method already defined in its base class, resolved at run time via the virtual/override keywords.
C#
class Animal
{
    public virtual void Sound() => Console.WriteLine("Animal makes a sound");
}

class Dog : Animal
{
    public override void Sound() => Console.WriteLine("Dog barks");
}

Animal a = new Dog();
a.Sound(); // "Dog barks" — decided at runtime based on actual object type

Interview trap: "What happens if you remove virtual from the base method?" → The derived method hides the base one (needs new keyword) instead of overriding it — this is called method hiding, and it's resolved at compile time based on the reference type, not the object type. This trips up a lot of candidates, so know it cold:

Animal a = new Dog();
a.Sound(); // WITHOUT virtual/override → calls Animal's Sound(), NOT Dog's

Overloading vs Overriding — the classic comparison question
Aspect	Overloading	Overriding
Binding	Compile-time (static)	Runtime (dynamic)
Signature	Must differ	Must be same
Keyword	None needed	virtual + override
Class	Same class	Base & derived class
Inheritance needed?	No	Yes
-------------------------------------------------------
6.Encapsulation
Wrapping data (feilds) and the methods that operate on them into a single unit(class),while restricting direct access to the internal state. Done using access modifies + properties.
C#
class BankAccount
{
    private double balance; //hidden from outside

    public double GetBalance() => balance;

    public void Deposit(double amount)
    {
        if (amount > 0) balance += amount;
    }
}

Nobody outside the class can do account.balance = -5000; directly -- they're forced to go thrugh Deposit(), which can validate input. This is the real point of encapsulation: controlled access ,not just "hiding for hiding's sake."

Properties are C#'s cleaner syntax for this pattern:
C#

class Employee
{
    private double salary;
    public double Salary
    {
        get{  return salary; }
        set { if(value > 0) salary = value;}
    }
}

Intervire trap: "Isn't public property with get/set the same as a public field?" ->No -a property can add validation logic (as above) and can later change internally without breaking code that uses it. A public field can't do either.
-----------------------------------------------------
7.Abstraction
Hiding implementation details and exposing only what's necessary.Achieved via abstract classes and interfaces.

C#
abstract class Shape
{
    public abstract double GetArea(); //no body - must be implemented by derived class
    public void Display() => Console.WriteLine("This is a shape");
}

class Circle : Shape
{
    publice double Radius;
    public override double GetArea() => Math.PI * Radius * Radius;
}

* Cannot be instantiated direcrly (new Shape() is illegel)
* Can mix abstract methods(no body) with regular,fully-implemented methods
* A class can inherit from only one abstract class(single inheritance rule still applies)


8.Interface

C#
 interface IShape
 {
    double GetArea(); //no body,no access modifier -Implicitly public

 }

 class Square :Ishape
 {
    public double Side;
    publc double GetArea()=> Side * Side;
 } 

 * Traditionally, interfaces couldn't have any implementation at all (pre-C# 8)- just method signatures
 *A class can implement multiple interfaces - this is how C# gets around not supporting multiple class inheritance
 *All members are implicitly public  

// Abstract class vs Interface — the classic comparison question
Aspect	Abstract Class	Interface
Implementation	Can have both abstract and concrete methods	Traditionally none (default methods allowed since C# 8, but rarely the expected answer)
Fields	Can have fields	Cannot have fields
Inheritance	Single only	Multiple allowed
Constructors	Can have one	Cannot have one
When to use	"IS-A" relationship with shared code	"CAN-DO" capability contract

 Interview trap: "When would you use an abstract class over an interface?" → When derived classes share common, reusable implementation (not just a method signature) — e.g., all Shapes need a Display() method with identical logic. Use an interface when unrelated classes need to guarantee the same capability (e.g., IComparable, IDisposable).
--------------------------------------------------------------------------

9.sealed keyword
 Prevents class from being inherited further,or a method from being overridden further.

 C#
 sealed class FinalClass
 {
    //cannot be inherited by any other class
 }
 class Animal
 {
    public virtual void Sound() => Console.WriteLine("...");

 }
 class Dog : Animal
 {
    public sealed override void Sound() => Console.WriteLine("Bark"); //can't be overridden further
 }
 Interview trap: "Why would you seal a class?" → Performance (compiler can optimize since it knows no override exists) and design intent — locking down a class you don't want extended, like a security-sensitive utility class.
 ----------------------------------------------------
 10 this vs base keyword
 * this refers to the current object instance - used to disambiguate fields from parameters, or to call another constructor in the same class.
 * base refers to the parent class - used to call the parent's constructor or a parent's method that was overridden.

 C#

 class Animal
{
    public Animal() => Console.WriteLine("Animal constructor");
    public virtual void Sound() => Console.WriteLine("Some sound");
}

class Dog : Animal
{
    public Dog() : base() => Console.WriteLine("Dog constructor"); // calls Animal's constructor first
    public override void Sound()
    {
        base.Sound();   // calls Animal's version first
        Console.WriteLine("Bark");
    }
}

Interview trap: "Does the base class constructor run automatically?" → Yes — even without writing : base() explicitly, the parameterless base constructor runs first, before the derived class's constructor body executes.
---------------------------------------------------------
10.Access Modifiers
public - Anywhere
private - Only within the same class
protected - Same class + derived classes
internal - Same assembly/ project only
protected internal - Same assembly OR derived classes (even in other assemblies)
private protected -same assembly AND derived classes only
 