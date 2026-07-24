#Day 1 -Fundamentals
## CLR (Cmmon Language Runtime)
The engine that runs C# code.
Manges memory,Security ,and exceptions sits between compiled code and share types.

## CTS (Common Type System)
The rulebook defining how types (int,string,class ,etc.) are declare so different .NET language can share types.

## CLS (Comman Language Specification)
A smaller subset of CTS rules. Following them guarantees your code can be used by any .NET Language.

## JIT Compiler (Just-In-Time)
C# compiles to IL (Intermidiate Language) first,not machine code.When then program runs,JIT converts IL to native machine code at that moment, for that specific machine.

## Managed vs Unmanaged code
Managed Code runs under the CLR (memory managed for you, garbage collected).
Unmanaged Code (like raw C/C++) require manual memory mangement.
C# is managed by default

## Value vs Reference Types
Value types (int, bool, struct) hold the actual data directly.
Reference types (class, string ,array) hold a pointer to where the data lives.
Copying a value type copies the data.Copying a reference type copies the pointer

## Stack Vs Heap
Stack: stores value types and method call frames. Fast,auto-cleaned when a method ends.
Heap: stores reference types.Managed by the garbage collector, slower but flexible.

## Boxing vs Unboxing
Boxing = Converting a value type into a reference type (wrapping int into object).
Unboxing = Converting it back. Boxing has a performance cost (stack to heap move).
````````C#.
int num=310;
object boxed =num; //boxing
int unboxed = (int)boxed  // Unboxing
```````````````````````````````````````
## Variables
A named storage location with a type.
`````````c#
int age = 25;
`````````````

## const vs readonly
const: fixed at compile time ,must be assigned at declaration, implicitly static.
readonly: can be assingned at declaration on in a constructor, can differ per instance.

``````````````C#
const double pi = 3.14159;
readonly int id;
public MyClass(int x) {id = x;}
```````````````````````````````

## var vs dynamic
var: still statically typed - compiler locks the type in at compile time.
dynamic: type-checking skipped untill runtime - flexible but riskier and slower.

`````````C#
var x=10;  //Compiler knows x is int , forever
dynamic y=10; // y colud become anything later
``````````````````````````````````````````````
## String vs StringBuilder
string: immutable - every "change" creates a new string in memory
StringBuilder: mutable - modifies an internal buffer in place, faster for loops.

## Parse vs Convert vs TryParse
-int.Parse("123") - throws exception if invalid.
-Convert.ToInt32("123")- handles null (returns 0),converts between more types.
-int.TryParse("123", out int result) - safest ,retruns true/false instead of threwing.








