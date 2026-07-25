Console.Write("Enter a number:");
int number =int.Parse(Console.ReadLine());

long factorial = 1;
for(int i = 1; i <= number; i++)
{
    factorial *=i;
}
Console.WriteLine($"Factorial of {number} is {factorial}");
// ``````````````````````````````````````
Console.Write("Enter a number:");
int number1=int.Parse(Console.ReadLine());
int fact=1;
for(int i = 1; i <= number1; i++)
{
    fact *=i;

}

Console.WriteLine($"Factorial of {number1} is {fact}");