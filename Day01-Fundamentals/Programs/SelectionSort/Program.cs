// Key logic — how this differs from Bubble Sort:

// Bubble Sort repeatedly swaps adjacent elements as it goes
// Selection Sort instead scans the whole remaining unsorted portion to find the minimum, then does just one swap to place it correctly — fewer swaps overall, but still the same number of comparisons
// Outer loop (i) marks the boundary between the sorted portion (left) and unsorted portion (right)
// Inner loop (j) searches only the unsorted portion for the smallest value, tracking its position in minIndex
// After the inner loop finishes, we swap that minimum into position i — locking in one more correctly-placed element each pass


int[] numbers = {64,25,12,22,11};
int n = numbers.Length;
for(int i = 0; i < n - 1; i++)
{
    int minIndex = i ;
     
     for(int j = i + 1; j < n; j++)
    {
        if(numbers[j] < numbers[minIndex])
        {
            minIndex = j;
        }
    }
    //swap then found minimum with the first unsorted element
int temp = numbers[minIndex];
numbers[minIndex] = numbers[i];
numbers[i] = temp;
}

Console.WriteLine("Sorted Array: " + string.Join(", ", numbers));