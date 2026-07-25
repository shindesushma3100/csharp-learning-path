// Key logic:

// Start by assuming the first element is the largest
// Walk through every other element — whenever you find something bigger, update largest
// By the end, you've compared every element and largest holds the true maximum
// (Side note: C# also has a built-in numbers.Max() that does this in one line — good to know for real projects, but writing the loop yourself first builds the underlying intuition)
//Largest Number
int[] numbers={45,12,89,33,67};
int largest = numbers[0];
foreach(int num in numbers)
{
    if (num > largest)
    {
        largest=num;
    }
}
Console.WriteLine("Array: "+ string.Join(", ", numbers));
Console.WriteLine($"Largest number: {largest}");

//Second Largest
int[] numbers1 = { 45, 12, 89, 33, 67 };
int largest2 =int.MinValue;
int secondLargest= int.MinValue;
foreach(int num in numbers1)
{
    if(num > largest2)
    {
        secondLargest= largest2;
        largest2 = num;
    }
    else if(num > secondLargest && num != largest2)
    {
        secondLargest = num;
    }

}
Console.WriteLine("Array: "+ string.Join(", ", numbers1));
Console.WriteLine($"Largest:{largest2}, Second Largest: {secondLargest}");
