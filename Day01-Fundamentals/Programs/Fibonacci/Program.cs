// Key logic:

// Each number is the sum of the two before it
// We keep two "tracker" variables (first, second) and slide them forward each loop — no need to store the whole sequence in an array for this version
// Console.Write (not WriteLine) keeps everything on one line, with a final WriteLine() just to add a line break at the end

Console.Write("Enter number of terms:");
int n = int.Parse(Console.ReadLine());
int first =0, second=1;
Console.Write("Fibonacci Serires: ");
for(int i = 0; i < n; i++)
{
    Console.Write(first + "");
    int next = first+ second;
    first=second;
    second=next;
}
Console.WriteLine();