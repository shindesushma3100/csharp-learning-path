// Key logic:

// Check every element one by one, from the start, until you find a match or reach the end
// foundIndex = -1 as a starting "not found" marker is a common pattern — array indices are always ≥ 0, so -1 safely means "nothing yet"
// break stops the loop early the moment we find it — no point checking the rest
// This works on any array (sorted or not), but it's slow for large data — O(n) in the worst case, since you might have to check every single element

int[] numbers = {34,12,89,45,67,23};
Console.Write("Enter number to seach: ");
int target = int.Parse (Console.ReadLine());

int foundIndex=-1;
for(int i=1; i < numbers.Length; i++)
{
    if(numbers[i] == target)
    {
        foundIndex = i;
        break;
    }
}
if(foundIndex!=-1)
{
    Console.WriteLine($"{target} found at index {foundIndex}");

}
else
{
     Console.WriteLine($"{target} not found in array");
}