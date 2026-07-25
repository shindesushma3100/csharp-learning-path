Console.Write("Enter a string: ");
string input=Console.ReadLine();
string vowles="aieou";
int count=0;
foreach(char c in input)
{
    if (vowles.Contains(c))
    {
        count++;
    }
}
Console.WriteLine($"Number of vowels: {count}");