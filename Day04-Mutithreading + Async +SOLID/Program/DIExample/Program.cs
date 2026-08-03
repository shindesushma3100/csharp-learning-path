//Abstraction - what orderService depends on
interface INotificationService
{
    void Notify(string message);
}
interface IPaymentProcessor
{
    bool ProcessPayment(double amount);
}
//Concrete implementation
class EmailNotificationService : INotificationService
{
    public void Notify(string message) => Console.WriteLine($"[Email] {message}");

}
class SmsNotificationService : INotificationService
{
    public void Notify(string message) => Console.WriteLine($"[SMS] {message}");
}

class CreditCardProcessor : IPaymentProcessor
{
    public bool ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing ${amount} via Credit Card...");
        return true;
    }
}
//High - level class -depends only on abstractions,injected via constructor
class OrderService
{
    private readonly IPaymentProcessor paymentProcessor;
    private readonly INotificationService notificationService;
    public OrderService(IPaymentProcessor paymentProcessor,INotificationService notificationService)
    {
        this.paymentProcessor = paymentProcessor;
        this.notificationService = notificationService;
    }

    public void PlaceOrder(string product,double amount)
    {
        Console.WriteLine($"Placing order for {product}...");

        if (paymentProcessor.ProcessPayment(amount))
        {
            notificationService.Notify($"Order for {product} confirmed. Amount: ${amount}");
        }
        else
        {
            notificationService.Notify($"Payment failed for {product}.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("-- Using Email notification --");
        OrderService emailOrderService = new OrderService(
            new CreditCardProcessor(),
            new EmailNotificationService()
        );
        emailOrderService.PlaceOrder("Laptop",55000);
        Console.WriteLine("\n -- Same OrderService, swappe to SMS notifications --");
        OrderService smsOrderService = new OrderService(
            new CreditCardProcessor(),
            new SmsNotificationService()
        );
        smsOrderService.PlaceOrder("Mouse",500);
    }
}

// Key logic — this is DI at its most useful:

// OrderService never creates a CreditCardProcessor or EmailNotificationService internally — both are handed to it from outside, through the constructor
// Notice how easy it was to swap EmailNotificationService for SmsNotificationService in the second call — zero changes needed inside OrderService itself. That's the entire payoff of Dependency Injection: your high-level logic stays stable while the specific implementations underneath can change freely
// In real-world .NET apps, you'd typically use a DI Container (built into ASP.NET Core, for example) to wire these dependencies up automatically instead of manually new-ing them in Main — but understanding this manual version first is exactly what makes the container version make sense later