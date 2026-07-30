# Collection 

Q: What's the difference between an Array and a List in C#?
"An array has a fixed size — once you create it with, say, 5 slots, it's always exactly 5 slots. A List is dynamic — it grows or shrinks automatically as you add or remove items. In practice, I use List far more often because I rarely know the exact size upfront."

Q: Why would you ever use an array instead of a List then?
"Performance, mostly. Arrays are slightly faster and use less memory because there's no overhead for resizing. If I know the size will never change — like the 7 days of the week — an array makes sense. Otherwise, List is more practical."

Q: What's ArrayList, and why don't people use it anymore?
"ArrayList is the old-school, non-generic version of List. It stores everything as object, which means it has no type safety — you could accidentally put a string and an int in the same ArrayList and the compiler wouldn't stop you. It also causes boxing/unboxing overhead for value types. List<T> fixed all of that, so ArrayList is basically legacy code at this point."

Q: When would you use a Dictionary over a List?
"When I need to look something up by a unique key instead of searching through everything. Like if I have thousands of employees and I want to find one by their ID instantly, a Dictionary gives me near-instant lookup. A List would have to check each item one by one until it finds a match."

Q: What makes HashSet different from a List?
"HashSet automatically prevents duplicates — if I try to add the same value twice, it just ignores the second one. A List would happily let me add the same value 100 times. I use HashSet whenever uniqueness actually matters, like tracking which usernames have already signed up."

Q: Explain Queue and Stack, and where you'd actually use them.
"Queue is First-In-First-Out — think of a real queue at a billing counter, whoever came first gets served first. I'd use it for something like a print job queue or task processing order. Stack is the opposite, Last-In-First-Out — like a stack of plates, you take from the top. Classic use case is the 'undo' feature in an app, or how function calls work behind the scenes in any programming language."

Q: What's a LinkedList, and why not just always use a List?
"A LinkedList is a chain of nodes, each pointing to the next one. Inserting or removing something in the middle is fast because you're just changing a couple of pointers. But you lose fast random access — to get to the 500th item, you have to walk through all 499 before it, whereas a List can jump straight there. So it's a tradeoff: LinkedList wins for frequent middle-insertions, List wins for random access."

Q: What's Hashtable, and how is it different from Dictionary?
"Hashtable is Dictionary's older, non-generic ancestor — same idea, key-value pairs, but it stores things as object, so again, no type safety and boxing overhead for value types. Dictionary<TKey, TValue> is the modern replacement — I genuinely can't think of a reason to reach for Hashtable in new code."

Q: What are Concurrent Collections, and when do you actually need them?
"Regular collections like List or Dictionary aren't safe if multiple threads try to read and write to them at the same time — you can end up corrupting the data or throwing exceptions. Concurrent Collections, like ConcurrentDictionary or ConcurrentQueue, are built specifically to handle multiple threads safely. You'd only reach for these in multi-threaded scenarios — if your app is single-threaded, they're unnecessary overhead."

Q: What's the difference between IEnumerable and IEnumerator?
"IEnumerable is what says 'this thing can be looped over' — if a class implements it, you can use foreach on it. IEnumerator is the actual mechanism doing the work underneath — it has a MoveNext() method and a Current property. Basically, when you write a foreach loop, C# is quietly calling IEnumerator's methods behind the scenes for you."

Q: What's the difference between IEnumerable, ICollection, and IList?
"Think of it as three layers building on each other. IEnumerable just lets you loop through something — that's it. ICollection adds the ability to know the Count and to Add or Remove items. IList goes a step further and lets you access items by index, like list[0]. So IEnumerable is the loosest contract, IList is the most specific."

Q: Why would you write a method that accepts IEnumerable<T> instead of List<T>?
"Flexibility. If my method takes IEnumerable<T>, it works with a List, an array, a HashSet — literally anything that can be looped over. If I specifically require List<T>, I've locked out anyone using a different collection type, even if my method never actually needed List-specific features like indexing. It's a habit of writing more reusable code."

Q: What's IDictionary, and why isn't it just called IList for key-value pairs?
"IDictionary is the contract for anything that stores key-value pairs — it guarantees things like being able to look up a value by key, or check if a key exists. Dictionary<TKey,TValue> and Hashtable both implement it. It's separate from IList because a dictionary doesn't have a numeric index like dict[0] — you access it by key, not position."

# Exception Handling

Q: What's the difference between try, catch, and finally?
"try is where you put code that might fail. catch is what runs if something actually goes wrong inside that try block — it lets you handle the error instead of the whole program crashing. finally runs no matter what — whether an exception happened or not — so I use it for cleanup, like closing a file or a database connection."

Q: Will finally run even if there's a return statement inside try?
"Yes, and this trips people up. Even if the try block hits a return, C# still executes the finally block before actually returning. The only real exception is if the process itself terminates unexpectedly, like a system crash — but under normal circumstances, finally is basically guaranteed to run."

Q: What's the difference between throw and throw ex?
"throw by itself re-throws the current exception and preserves the original stack trace — so you can still see exactly where it originally happened. throw ex resets the stack trace to this new point, which makes debugging harder because you lose the original error location. I always use plain throw when re-throwing inside a catch block."

Q: Why would you create a custom exception instead of just using Exception?
"Because a custom exception makes the error meaningful. If I throw a generic Exception, whoever catches it has no idea what actually went wrong without reading a message string. If I create something like InsufficientBalanceException, the type itself tells the story, and I can also attach extra data specific to that situation — like the attempted amount and the current balance."

Q: How do you create a custom exception in C#?
"You just inherit from the built-in Exception class."

csharp
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

"Then I can throw it just like any built-in exception: throw new InsufficientBalanceException("Not enough funds");"

Q: Can you have multiple catch blocks? How does C# decide which one runs?
"Yes, and C# checks them top to bottom, running the first one that matches the exception type. Because of that, you always put more specific exceptions first and general ones like catch (Exception e) last — otherwise the general one would catch everything before the specific ones ever get a chance."

Q: Is using try-catch for normal program flow control a good idea?
"No, and this is something interviewers like to probe. Exceptions are meant for truly unexpected situations, not for things like checking if a string is a valid number — that's what TryParse exists for. Using exceptions for regular logic is slower and makes code harder to read, since exceptions are relatively expensive operations in terms of performance."

# LINQ

Q: What is LINQ, in plain terms?
"LINQ lets me query collections — Lists, arrays, Dictionaries — using readable, SQL-like syntax instead of writing manual loops. Instead of looping through a list of employees to find the ones earning above a certain salary, I can just write one line describing what I want, and LINQ figures out how to get it."

Q: What does Where do?
"It filters a collection based on a condition, and returns only the items that match. Like employees.Where(e => e.Salary > 50000) — gives me back only the employees earning more than 50k."

Q: What does Select do, and how is it different from Where?
"Where filters which items you keep. Select transforms each item into something else — like pulling out just the names from a list of employee objects instead of the whole object: employees.Select(e => e.Name). One narrows the list, the other reshapes it."

Q: What does OrderBy do?
"Sorts a collection, ascending by default. employees.OrderBy(e => e.Salary) sorts lowest to highest. If I want highest to lowest, I use OrderByDescending instead."

Q: What does GroupBy actually do — this one confuses people.
"It buckets items together based on a shared key. Like grouping employees by department — employees.GroupBy(e => e.Department) gives me back groups, where each group has a key (the department name) and a collection of all employees in that department. It's basically the LINQ version of a SQL GROUP BY."

Q: What's the difference between Distinct, Union, and Intersect?
"Distinct removes duplicates from a single collection. Union combines two collections and removes duplicates between them. Intersect gives you only the items that exist in both collections. So if I have two lists of customer IDs, Union tells me everyone across both, Intersect tells me who's in both lists at once."

Q: Explain Join, and Inner Join vs Left Join.
"Join combines two collections based on a matching key, like matching Customers to their Orders using a CustomerId. An Inner Join only returns records where a match exists on both sides — if a customer has no orders, they're left out entirely. A Left Join keeps every record from the left collection regardless of whether a match exists — so every customer shows up, even ones with zero orders, just with empty order data."

Q: What's the difference between Any and All?
"Any checks if at least one item matches a condition — returns true the moment it finds one. All checks if every single item matches — one failure and it returns false immediately. employees.Any(e => e.Salary > 100000) asks 'does anyone earn over 100k?' while All would ask 'does everyone earn over 100k?'"

Q: What's the difference between First, FirstOrDefault, and Single?
"First returns the first matching item, but throws an exception if nothing matches. FirstOrDefault does the same thing, but returns a default value — like null, or 0 — instead of crashing if nothing's found, which makes it much safer for real code. Single is stricter than both — it expects exactly one match, and throws an exception if there's zero OR more than one. I'd use Single when I'm confident there should only ever be one result, like looking up a user by a unique ID."

Q: What do Skip and Take do?
"They're built for pagination. Skip(10) ignores the first 10 items, Take(5) then grabs the next 5. So Skip(10).Take(5) gives you page 3 if each page shows 5 results — this pattern shows up constantly in real applications with paged data tables."

Q: What does Aggregate do?
"It lets you reduce a whole collection down to one single value by applying a function repeatedly, item by item. Like numbers.Aggregate((total, n) => total + n) to sum a list manually — though for something that simple, you'd normally just use Sum(). Aggregate is more useful for custom accumulation logic that doesn't have a built-in method already."

