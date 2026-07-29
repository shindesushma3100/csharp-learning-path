//Abstract class - can mix abstract + concrete methods
abstract class Shape
{
    public abstract double GetArea(); //no body
    public void Display()=> Console.WriteLine("This is a shape");
}
class Circle : Shape
{
    public double Radius;
    public Circle(double radius) => Radius =radius;
     public override double GetArea() => Math.PI * Radius * Radius;
}

//Interface - pure capability contract
interface IResizable
{
    void Resize(double factor);
}
class Square : Shape, IResizable
{
    public double Side;
    public Square(double side)=>Side=side;
    public override double GetArea()=> Side * Side;
    public void Resize(double factor)
    {
        Side *= factor;
        Console.WriteLine($"Square resized . New Side:{Side}");
    }
 
}
class Prgram
{
    static void Main()
    {
         Circle circle = new Circle(5);
        circle.Display();               // inherited concrete method
        Console.WriteLine($"Circle area: {circle.GetArea()}");

        Square square = new Square(4);
        square.Display();
        Console.WriteLine($"Square area: {square.GetArea()}");
        square.Resize(2);                // from interface
        Console.WriteLine($"Square area after resize: {square.GetArea()}");

        // Shape s = new Shape(); // this would NOT compile - abstract classes can't be instantiated
    }
}