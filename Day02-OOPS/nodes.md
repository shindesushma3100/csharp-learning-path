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

----------------------------------------4. Inheritance

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