class Logger
{
    private static Logger instance;
    private static readonly object lockObj = new object();
    private int logCount = 0;

    //private constructor - nobody outside can do "new Logger()"

    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }

    public static Logger Instance
    {
        get
        {
            lock (lockObj)
            {
                if(instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
    }

    public void Log(string message)
    {
        logCount ++;
        Console.WriteLine($"[Log #{logCount}] {message}");
    }
}

class Program
{
    static void Main()
    {
        Logger logger1 =Logger.Instance;
        logger1.Log("First Message");

        Logger logger2 = Logger.Instance; //same instance, NOT a new one
        logger2.Log("Second Message");

        Console.WriteLine($"\n Are logger1 and logger2 the same object? {ReferenceEquals(logger1,logger2)}");
        
    }
}