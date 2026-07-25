// Key logic: % 2 gives the remainder when dividing by 2. Any even number has remainder 0; any odd number has remainder 1. This is the simplest and fastest way to check — no need for anything fancier.

Console.Write("Enter Number:");
int input = int.Parse(Console.ReadLine());

int cheknumber= input % 2;

if (cheknumber == 0)
{
    Console.WriteLine($"{input} is Even number");
}
else
{
    Console.WriteLine($"{input} is Odd number");
}
