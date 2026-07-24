// Console.Write("Enter a String :");
// string input = Console.ReadLine();

// char[] chars = input.ToCharArray();
// Array.Reverse(chars);
// string reversed =new  string(chars);

// Console.WriteLine($"Reversed String:{reversed}");

//Array Reverse
Console.Write("Enter String :");
string input= Console.ReadLine();

char[] chars= input.ToCharArray();
Array.Reverse(chars);

string reversed =new  string(chars);
Console.WriteLine($"Reversed String :{reversed}");

//String Reverse

Console.Write("Enter 2nd String :");
string input2 = Console.ReadLine();
string stringarr = input2.ToString();
string temp = new  string(stringarr.Reverse().ToArray());
Console.WriteLine(temp);

