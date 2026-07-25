// Key logic (the big idea in Binary Search):

// Requirement: the array must already be sorted — this is the whole trick that makes it fast
// Instead of checking every element, check the middle one. Since the array is sorted, you instantly know which half the target must be in — no need to look at the other half at all
// Each loop cuts the search space in half — this is why it's so much faster than Linear Search: O(log n) instead of O(n). For an array of 1,000,000 elements, Linear Search might take a million checks; Binary Search takes about 20
// low and high track the current search boundaries, shrinking each time we rule out a half

int[] numbers = {11,12,25,34,64,90};
Console.Write("Enter number to search: ");
int target = int.Parse(Console.ReadLine());
int low = 0;
int high = numbers.Length -1;
int foundIndex = -1;
while(low <= high)
{
    int mid =(low + high)/2;
    if(numbers[mid] == target)
    {
        foundIndex = mid;
        break;
    }
    else if(numbers[mid]< target)
    {
        low = mid +1 ;
    }
    else
    {
        high = mid - 1;
    }
}

if(foundIndex != -1)
{
    Console.WriteLine($"{target} found at index {foundIndex}");
}
else
{
    Console.WriteLine($"{target} not found in array");
}