

using System.Linq;

// Console.Write("Enter Name :");
string name= "Sushma Shinde".ToLower().Replace(" ","");

var duplicate = name
                .GroupBy(c => c)
                .Where(g => g.Count()> 1);

foreach(var c in duplicate)
{
    Console.WriteLine($"{c.Key} = {c.Count()}");
}