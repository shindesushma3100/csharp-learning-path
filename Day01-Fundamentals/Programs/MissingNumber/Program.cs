// Key logic (a neat math trick, worth remembering):

// The sum of numbers from 1 to N has a formula: n * (n + 1) / 2 — no need to loop to calculate it
// Compare that expected sum to the actual sum of your array
// Whatever's missing from the array is exactly the difference between the two — since only one number is missing, that gap tells you precisely which one 

int[] numbers = {1,2,3,4,6};
int n=6;
int expectedSum = n*(n+1)/2;
int actualsum=0;
foreach(int num in numbers)
{
    actualsum += num;
}
int missing = expectedSum - actualsum;
Console.WriteLine("Array: "+ string.Join(", ", numbers));
Console.WriteLine($"Missing Number: {missing}");