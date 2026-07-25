
// Key logic (take your time with this one):

// The idea: repeatedly compare adjacent pairs and swap them if they're in the wrong order — the largest value "bubbles up" to the end each pass
// Outer loop (i) controls how many full passes we make through the array
// Inner loop (j) does the actual comparing and swapping (using the same swap technique from your Swap Numbers program earlier)
// n - i - 1 shrinks the inner loop's range each pass, because after each pass, the largest remaining element is already correctly placed at the end — no need to recheck it
// This is not the fastest sorting algorithm (it's O(n²) — slow for large arrays), but it's the clearest one to learn from first

int[] numbers = {64,34,25,12,22,11,90};

int n = numbers.Length;
for(int i =0; i< n-i-1; i++)
{
    for(int j=0; j<n-1-1; j++)
    {
        if (numbers[j] > numbers[j + 1])
        {
            int temp = numbers[j];
            numbers[j]= numbers[j+1];
            numbers[j+1]=temp;
        }
    }
}
Console.WriteLine("Sorted Array: "+ string.Join(", ",numbers));