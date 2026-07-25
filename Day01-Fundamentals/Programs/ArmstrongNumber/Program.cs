// Key logic:

// number % 10 extracts the last digit (e.g., 153 % 10 = 3)
// number / 10 chops off that last digit using integer division (153 / 10 = 15)
// We repeat this until number becomes 0, meaning we've processed every digit
// Math.Pow(digit, digitCount) raises each digit to the power of the total digit count, and we sum them all

using System.ComponentModel;

Console.Write("Enter a number: ");
int number = int.Parse(Console.ReadLine());

int original = number;
int digitCount = number.ToString().Length;
int sum=0;

while (number > 0){
    int digit =number %10;
    sum += (int)Math.Pow(digit,digitCount);
    number = number/10;
}
if (sum == original)
{
    Console.WriteLine($"{original} is Armstrong Number");
}
else
{
    Console.WriteLine($"{original}is NOT an Armstrong Number");
}