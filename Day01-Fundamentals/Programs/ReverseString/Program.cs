// Console.Write("Enter a String :");
// string input = Console.ReadLine();

// char[] chars = input.ToCharArray();
// Array.Reverse(chars);
// string reversed =new  string(chars);

// Console.WriteLine($"Reversed String:{reversed}");


Console.Write("Enter String :");
string input= Console.ReadLine();

char[] chars= input.ToCharArray();
Array.Reverse(chars);

string reversed =new  string(chars);
Console.WriteLine($"Reversed String :{reversed}");