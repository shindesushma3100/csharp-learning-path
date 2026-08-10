
//Using LINQ
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

//Usig HasSet<>
HashSet<char>seen=new HashSet<char>();
HashSet<char>duplicates=new HashSet<char>();

foreach(char ch in name)
{
    if (!seen.Add(ch))
    {
        duplicates.Add(ch);
    }

}
        Console.WriteLine($"Name :{name.ToUpper()}");
        Console.WriteLine("Duplicate Charaters: "+ string.Join(", ",duplicates));

