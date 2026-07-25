Console.Write("Enter a string: ");
string input=Console.ReadLine();

//Count vowels
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
//Count word

int cout2 =input.ToString().Length;
Console.WriteLine($"Number of count of {input} is {cout2}");