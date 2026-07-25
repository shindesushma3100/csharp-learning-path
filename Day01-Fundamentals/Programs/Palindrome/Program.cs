// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

Console.Write("Enter a string:");
string input =Console.ReadLine();

string reversed = new string(input.Reverse().ToArray());
if(input == reversed)
{
    Console.WriteLine($"{input} is a Palindrome");

}
else
{
    Console.WriteLine($"{input} is not a Palindrome");
}

Console.Write("Enter String :");
string input2= Console.ReadLine();
string reversedd= new string(input2.Reverse().ToArray());
if(input2 == reversedd)
{
    Console.WriteLine($"{input2} is a palindrome");
}
else
{
    Console.WriteLine($"{input2} is not a palindrome");
}