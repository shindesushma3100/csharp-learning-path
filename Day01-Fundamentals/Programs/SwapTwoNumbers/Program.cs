// Next: Swap Two Numbers — a classic for understanding how variables actually hold values.
// Key logic:

// Approach 1 is the standard, always-safe way — store one value in a temporary box before overwriting it
// Approach 2 is a classic interview trick avoiding extra memory, but it's riskier — with very large numbers a + b could overflow. Good to know, but Approach 1 is what you'd use in real code


Console.Write("Enter First Number:");
int a =int.Parse(Console.ReadLine());
Console.Write("Enter Second Number:");
int b =int.Parse(Console.ReadLine());
Console.WriteLine($"Before Swap: a={a},b={b}");

//Approch 1 : Using a temporary variable
int temp= a;
a=b;
b=temp;

Console.WriteLine($"After swap (temp variable):a={a},b={b}");

//Aprroch 2 :Withou a temporary variable(arithmetic trick)

a = a + b;
b = a - b;
a = a - b;


Console.WriteLine($"After Swap (No Temp ,arithmetic): a={a},b={b}");