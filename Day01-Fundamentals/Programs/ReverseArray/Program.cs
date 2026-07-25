// Key logic:

// string.Join(", ", numbers) is the clean way to print an array's contents as a readable line — much better than looping with Console.Write for each element
// Array.Reverse() is a built-in method that reverses the array in place (modifies the original array directly rather than creating a new one) — same method you used back in the Reverse String program, just applied to int[] instead of char[]

int[]numbers = {10,20,30,40,50};
Console.WriteLine("Original Array: "+ string.Join(",", numbers));

Array.Reverse(numbers);
Console.WriteLine("Reversed Array: "+ string.Join(",",numbers));