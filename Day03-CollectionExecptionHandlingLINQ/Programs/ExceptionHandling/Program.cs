class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message){ }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("-- Basic try/catch/finally --");
        try
        {
            int a =10;
            int b =0;
            int result = a/b;
            Console.WriteLine(result);
        }
        catch(DivideByZeroException e)
        {
            Console.WriteLine($"Caught: {e.Message}");
        }
        finally
        {
            Console.WriteLine("Fially block always runs,error or not.");
        }

        Console.WriteLine("\n -- Multiple catch bloks --");
        try
        {
            int[] numbers = {1,2,3};
            Console.WriteLine(numbers[5]);
        }
        catch (IndexOutOfRangeException e)
        {
             Console.WriteLine($"Specific catch: {e.Message}");
        }
        catch (Exception e) // general catch - must come LAST
        {
            Console.WriteLine($"General catch: {e.Message}");
        }

        Console.WriteLine("\n-- Custom Exception --");
        try
        {
            ProcessWithdrawal(5000, 2000);
        }
        catch (InsufficientBalanceException e)
        {
            Console.WriteLine($"Custom exception caught: {e.Message}");
        }
    }

    static void ProcessWithdrawal(double requested, double available)
    {
        if (requested > available)
        {
            throw new InsufficientBalanceException(
                $"Cannot withdraw {requested}, only {available} available.");
        }
        Console.WriteLine("Withdrawal successful.");
    }
}
