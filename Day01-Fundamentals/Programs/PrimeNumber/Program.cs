// A prime number has no divisors other than 1 and itself
// We only need to check divisors up to √number — if no factor exists below the square root, none exists above it either (this is why we don't loop all the way to number, it's a common efficiency trick)
// break exits the loop immediately once we find one divisor — no need to keep checking

Console.Write("Enter a number:");
int number = int.Parse(Console.ReadLine());
bool isPrime = true;
if(number < 2)
{
    isPrime = false;
}
else
{
    for(int i=2; i <= Math.Sqrt(number); i++)
    {
        if(number % i == 0)
        {
            isPrime = false;
            break;
        }
    }
}
Console.WriteLine(isPrime? $"{number} is Prime" : $"{number} is NOT Prime");