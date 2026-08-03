SQL — Joins

Q: Explain the different types of SQL Joins.
-Inner Join returns only rows that match in both tables. 
-Left Join returns everything from the left table, plus matches from the right — with NULLs where there's no match.
-Right Join is the mirror of that — everything from the right table, plus matches from the left.
-Full Join combines both — everything from both tables, matched where possible, NULL where not.
-Cross Join gives every possible combination of rows between two tables — no matching condition at all, so it's rarely used intentionally except for generating combinations. 
-Self Join is just a table joined to itself, useful for comparing rows within the same table, like finding employees who report to the same manager.

Q: When would you actually use a Self Join?
"A common example is an employee table with a ManagerId column pointing back to another EmployeeId in the same table. To show each employee alongside their manager's name, you join the table to itself — once as the employee, once as the manager."

GROUP BY and HAVING

Q: What's the difference between WHERE and HAVING?
"WHERE filters individual rows before any grouping happens.
 HAVING filters groups after GROUP BY has already combined rows. If I want departments where the total salary exceeds 500,000, I can't use WHERE for that because SUM doesn't exist until grouping happens — that's exactly what HAVING is for."

CTE (Common Table Expression)

Q: What's a CTE, and why use it instead of a subquery?
"A CTE is a temporary, named result set defined with WITH, that you can reference like a table within your query. It's mainly about readability — instead of nesting subqueries inside subqueries which gets hard to read, a CTE breaks the logic into a clear, named step. Functionally, simple CTEs and subqueries often perform the same, but CTEs are much easier to reason about, especially in complex queries."

Q: What's a Recursive CTE?
"It's a CTE that references itself, used for hierarchical data — like an org chart, where each employee has a manager who is also an employee. It has a base case (the starting row, like the top-level manager) and a recursive part that keeps joining back to itself until there's nothing left to add."

Window Functions

Q: What's the difference between RANK, DENSE_RANK, and ROW_NUMBER?
"All three assign a number to each row based on some ordering, but they handle ties differently. ROW_NUMBER always gives unique, sequential numbers, even if two rows tie — so ties get arbitrarily different numbers. RANK gives the same number to tied rows, but then skips the next number — like 1, 2, 2, 4. DENSE_RANK also gives ties the same number, but doesn't skip — like 1, 2, 2, 3. I'd use DENSE_RANK for something like 'top 3 distinct salary levels' since it doesn't leave gaps."

Stored Procedures, Views, Triggers

Q: What's a Stored Procedure, and why use one?
"It's precompiled SQL code stored in the database that you can call by name, optionally with parameters. Benefits: better performance since it's precompiled, reusability across applications, and it keeps complex logic centralized in the database instead of scattered across app code."

Q: What's a View?
"A View is a saved SQL query that acts like a virtual table — it doesn't store data itself, just the query definition. It's useful for simplifying a complex, frequently-used query, or for restricting access to only certain columns of a table without exposing the whole thing."

Q: What's a Trigger?
"A Trigger is code that automatically runs in response to an event on a table — like after an INSERT, UPDATE, or DELETE. A common use case is auditing — automatically logging who changed a row and when, without the application code having to remember to do it manually every time."

Indexes

Q: What's the difference between Clustered and Non-Clustered indexes?
"A Clustered index actually determines the physical order that data is stored on disk — there can only be one per table, because data can only be physically sorted one way. A Non-Clustered index is a separate structure that points back to the actual data — you can have many of these on one table. Think of a Clustered index like a phone book sorted alphabetically by name — that's the actual physical order. A Non-Clustered index is more like an index at the back of a book, pointing you to a page without the book itself being reordered."

Q: Why not just add indexes to every column?
"Indexes speed up reads, but they slow down writes — every INSERT, UPDATE, or DELETE has to update the index too. Too many indexes also uses more storage. It's a tradeoff — you index columns that are frequently searched or joined on, not everything."

Normalization

Q: What is Normalization, in simple terms?
"It's organizing your database tables to reduce data duplication and avoid inconsistency. Instead of repeating a customer's address in every single order row, you store the address once in a Customers table and just reference the customer's ID from Orders. It's typically explained in stages called Normal Forms — 1NF, 2NF, 3NF — each one removing a different kind of redundancy."

Q: Is normalization always the right choice?
"Not always — full normalization is great for data integrity, but it can mean more joins to reconstruct data, which can hurt read performance. In reporting or analytics-heavy systems, some intentional denormalization is common to make reads faster, trading off some redundancy for speed."

Transactions and ACID

Q: What's a Transaction?
"A group of database operations that either all succeed together, or all fail together — there's no in-between. Like transferring money between two bank accounts: subtracting from one account and adding to the other must both happen, or neither should, otherwise money disappears or gets duplicated."

Q: What does ACID stand for?
"Atomicity — the whole transaction succeeds or fails as one unit, no partial results. Consistency — the database moves from one valid state to another, never leaving it in a broken, invalid state. Isolation — transactions running at the same time don't interfere with each other's intermediate results. Durability — once a transaction is committed, it's permanently saved, even if the system crashes right after."

Q: How can a Deadlock happen at the database level?
"Same underlying idea as thread deadlocks — Transaction A locks Row 1 and wants Row 2, while Transaction B locks Row 2 and wants Row 1. Neither can proceed, and the database engine typically detects this and forcibly kills one of the transactions to break the deadlock, rolling it back."