using System.Collections.Generic;
class Program
{
  static void Main()
    {
        Console.WriteLine("--Array (fixed size)--");
        int[] arr = new int[3] {10,20,30};
        Console.WriteLine(string.Join(", ",arr));

        Console.WriteLine("\n -- List (dynamic) --");
        List<string> names = new List<string> {"Sushma","Ajit","Jyoti"};
        names.Add("Lalita");
        Console.WriteLine(string.Join(", ",names));

        Console.WriteLine("\n -- Dictionary (key-value) --");
        Dictionary<string ,int> ages =new Dictionary<string, int>
        {
            {"Sushma",25},
            {"Ajit",31},
            {"Jyoti",26}
        };

        foreach(var kv in ages)
        {
            Console.WriteLine($"{kv.Key} is {kv.Value} Years old");
        }

        Console.WriteLine("\n -- HashSet (Unique Only) --");
        HashSet<int> uniqueNumbers = new HashSet<int>{1,2,2,3,3,3};
        Console.WriteLine(string.Join(", ", uniqueNumbers));// duplicates auto-removed

        Console.WriteLine("\n -- Queue (FIFO) --");
        Queue<string> ticketLine =new Queue<string>();
        ticketLine.Enqueue("Customer1");
        ticketLine.Enqueue("Customer2");
        ticketLine.Enqueue("Customer3");
      Console.WriteLine($"Serving: {ticketLine.Dequeue()}"); //Customer 1 remove
      Console.WriteLine($"Serving: {ticketLine.Dequeue()}"); //Custome 2 remove

      Console.WriteLine("\n --Stack (LIFO)--");
      Stack<string> undoHistory = new Stack<string>();
      undoHistory.Push("Type letter A");
      undoHistory.Push("Type letter B");
      undoHistory.Push("Type letter C");
      Console.WriteLine($"Undo:{undoHistory.Pop()}"); // leter c
      Console.WriteLine($"Undo:{undoHistory.Pop()}"); // leter B
     

        Console.WriteLine("\n -- LinkedList --");
        LinkedList<string> tasks =new LinkedList<string>();
        tasks.AddLast("Task1");
        tasks.AddLast("Task2");
        tasks.AddFirst("UrgentTask"); //fast insertion in front
        foreach(var tk in tasks)
        {
            Console.WriteLine(tk);
        }

    }
}