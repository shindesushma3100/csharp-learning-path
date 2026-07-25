
// Key logic (new concept: HashSet):

// A HashSet<int> is a collection that only stores unique values — adding a duplicate has no effect
// seen.Add(num) returns true if the value was newly added, and false if it was already there — that return value is the trick this whole solution hinges on
// So !seen.Add(num) reads as "if this number was already in the set" → it must be a duplicate, so we add it to our duplicates set
// Using a second HashSet for duplicates (instead of a List) automatically avoids listing the same duplicate multiple times


int[] numbers = {10,20,30,10,50};
HashSet<int> seen = new HashSet<int>();
HashSet<int> duplicates= new  HashSet<int>();

foreach(int num in numbers)
{
    if (!seen.Add(num))
    {
        duplicates.Add(num);
    }
}
Console.WriteLine("Array: "+ string.Join(", ", numbers));
Console.WriteLine("Duplicate: "+ string.Join(", ", duplicates));
