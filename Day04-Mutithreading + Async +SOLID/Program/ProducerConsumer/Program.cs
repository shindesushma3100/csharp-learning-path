using System.Collections.Concurrent;
using System.Security.Authentication.ExtendedProtection;
class Program
{
    static BlockingCollection<int> queue = new BlockingCollection<int>(boundedCapacity : 5);

    static void Main()
    {
        Thread producer = new Thread(Produce);
        Thread consumer = new Thread(Consume);

        producer.Start();
        consumer.Start();

        producer.Join();
        consumer.Join();

    }

    static void Produce()
    {
        for(int i=1; i<=10; i++)
        {
            queue.Add(i);
            Console.WriteLine($"Produced: {i}");
            Thread.Sleep(100); //simulate work
        }

        queue.CompleteAdding(); //tells consumer no more items are coming
    }

    static void Consume()
    {
        foreach(int item in queue.GetConsumingEnumerable())
        {
            Console.WriteLine($" Consumed: {item}");
            Thread.Sleep(150); //simulate slower processing
        }
    }
}

// Key logic:

// BlockingCollection<T> (from System.Collections.Concurrent) is a thread-safe queue built exactly for this pattern — one thread adds items (producer), another removes and processes them (consumer)
// boundedCapacity: 5 means the producer will automatically pause if the queue fills up to 5 items and the consumer hasn't caught up yet — this prevents unbounded memory growth if production outpaces consumption
// CompleteAdding() signals "no more items will ever be added" — this is what lets the consumer's foreach loop know when to stop waiting and exit, instead of hanging forever
// Since the consumer is slower (150ms) than the producer (100ms), you'll see production get ahead, then pause once it hits the 5-item cap, waiting for consumption to catch up