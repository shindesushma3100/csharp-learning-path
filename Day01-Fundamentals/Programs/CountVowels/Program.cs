using System.Runtime.CompilerServices;

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
//Count character

int cout2 =input.ToString().Length;
Console.WriteLine($"Number of count of characer of {input} is {cout2}");

//Count Word
Console.Write("Enter a sentence: ");
string sentence= Console.ReadLine();
string[]words=sentence.Split(' ',StringSplitOptions.RemoveEmptyEntries);
Console.WriteLine($"Number of words: {words.Length}");