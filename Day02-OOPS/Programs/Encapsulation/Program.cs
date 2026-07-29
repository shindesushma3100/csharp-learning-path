class BankAccount
{
    private double balance; //hidden - no direct outside access

    public double Balance
    {
        get{return balance;}
        private set {balance = value;} //only this class can set
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance+= amount;
            Console.WriteLine($"Desposited {amount},New balance: {balance}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    public void Withdraw(double amount)
    {
        if(amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
        }
        else if(amount > balance)
        {
            Console.WriteLine("Insufficient balance.");
        }
        else
        {
            balance-=amount;
            Console.WriteLine($"Witdrew {amount},new balance:{balance}");
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account =new  BankAccount();
        account.Deposit(1000);
        account.Withdraw(300);
        account.Withdraw(5000); //should fail -insufficient balance
        account.Deposit(-50);   //should fail -invalid amount

        Console.WriteLine($"Final balance : {account.Balance}");
    }
}