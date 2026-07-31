using System.Diagnostics.Metrics;

class Counter
{
    public int Count = 0;
    public void Increment()
    {
        Count++; // NOT thread-safe
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("-- Without lock (race condition) --");
        RunTest(useLock: false);

        Console.WriteLine("\n -- With Lock (fixed) --");
        RunTest(useLock: true);
    }
    static readonly object lockobj =new object();
    static void RunTest(bool useLock)
    {
        Counter counter =new Counter();
        Thread[] threads =new Thread[10];

        for(int i = 0 ; i < 10; i++)
        {
            threads[i] =new Thread(()=>
            {
                for(int j =0; j < 100000; j++)
                {
                    if (useLock)
                    {
                        lock (lockobj)
                        {
                            counter.Increment();
                        }
                    }
                    else
                    {
                        counter.Increment();
                    }
                }
            });

        }

        foreach(var t in threads) t.Start();
        foreach(var t in threads) t.Join(); //wait for all threads to finish
    Console.WriteLine($"Expected:1,000,000, Actual:{counter.Count}");
    }

}