## SQL 
SQL — Joins

## Explain the different types of SQL Joins.
-Inner Join returns only rows that match in both tables. 
-Left Join returns everything from the left table, plus matches from the right — with NULLs where there's no match.
-Right Join is the mirror of that — everything from the right table, plus matches from the left.
-Full Join combines both — everything from both tables, matched where possible, NULL where not.
-Cross Join gives every possible combination of rows between two tables — no matching condition at all, so it's rarely used intentionally except for generating combinations. 
-Self Join is just a table joined to itself, useful for comparing rows within the same table, like finding employees who report to the same manager.

## When would you actually use a Self Join?
"A common example is an employee table with a ManagerId column pointing back to another EmployeeId in the same table. To show each employee alongside their manager's name, you join the table to itself — once as the employee, once as the manager."

## GROUP BY and HAVING

## What's the difference between WHERE and HAVING?
"WHERE filters individual rows before any grouping happens.
 HAVING filters groups after GROUP BY has already combined rows. If I want departments where the total salary exceeds 500,000, I can't use WHERE for that because SUM doesn't exist until grouping happens — that's exactly what HAVING is for."

## CTE (Common Table Expression)

## What's a CTE, and why use it instead of a subquery?
"A CTE is a temporary, named result set defined with WITH, that you can reference like a table within your query. It's mainly about readability — instead of nesting subqueries inside subqueries which gets hard to read, a CTE breaks the logic into a clear, named step. Functionally, simple CTEs and subqueries often perform the same, but CTEs are much easier to reason about, especially in complex queries."

## What's a Recursive CTE?
"It's a CTE that references itself, used for hierarchical data — like an org chart, where each employee has a manager who is also an employee. It has a base case (the starting row, like the top-level manager) and a recursive part that keeps joining back to itself until there's nothing left to add."

## Window Functions

## What's the difference between RANK, DENSE_RANK, and ROW_NUMBER?
"All three assign a number to each row based on some ordering, but they handle ties differently. ROW_NUMBER always gives unique, sequential numbers, even if two rows tie — so ties get   different numbers. RANK gives the same number to tied rows, but then skips the next number — like 1, 2, 2, 4. DENSE_RANK also gives ties the same number, but doesn't skip — like 1, 2, 2, 3. I'd use DENSE_RANK for something like 'top 3 distinct salary levels' since it doesn't leave gaps."

## Stored Procedures, Views, Triggers

## What's a Stored Procedure, and why use one?
"It's precompiled SQL code stored in the database that you can call by name, optionally with parameters. Benefits: better performance since it's precompiled, reusability across applications, and it keeps complex logic centralized in the database instead of scattered across app code."

## What's a View?
"A View is a saved SQL query that acts like a virtual table — it doesn't store data itself, just the query definition. It's useful for simplifying a complex, frequently-used query, or for restricting access to only certain columns of a table without exposing the whole thing."

## What's a Trigger?
"A Trigger is code that automatically runs in response to an event on a table — like after an INSERT, UPDATE, or DELETE. A common use case is auditing — automatically logging who changed a row and when, without the application code having to remember to do it manually every time."

## Indexes

## What's the difference between Clustered and Non-Clustered indexes?
"A Clustered index actually determines the physical order that data is stored on disk — there can only be one per table, because data can only be physically sorted one way. A Non-Clustered index is a separate structure that points back to the actual data — you can have many of these on one table. Think of a Clustered index like a phone book sorted alphabetically by name — that's the actual physical order. A Non-Clustered index is more like an index at the back of a book, pointing you to a page without the book itself being reordered."

## Why not just add indexes to every column?
"Indexes speed up reads, but they slow down writes — every INSERT, UPDATE, or DELETE has to update the index too. Too many indexes also uses more storage. It's a tradeoff — you index columns that are frequently searched or joined on, not everything."

## Normalization

## What is Normalization, in simple terms?
"It's organizing your database tables to reduce data duplication and avoid inconsistency. Instead of repeating a customer's address in every single order row, you store the address once in a Customers table and just reference the customer's ID from Orders. It's typically explained in stages called Normal Forms — 1NF, 2NF, 3NF — each one removing a different kind of redundancy."

## Is normalization always the right choice?
"Not always — full normalization is great for data integrity, but it can mean more joins to reconstruct data, which can hurt read performance. In reporting or analytics-heavy systems, some intentional denormalization is common to make reads faster, trading off some redundancy for speed."

## Transactions and ACID

## What's a Transaction?
"A group of database operations that either all succeed together, or all fail together — there's no in-between. Like transferring money between two bank accounts: subtracting from one account and adding to the other must both happen, or neither should, otherwise money disappears or gets duplicated."

## What does ACID stand for?
"Atomicity — the whole transaction succeeds or fails as one unit, no partial results. Consistency — the database moves from one valid state to another, never leaving it in a broken, invalid state. Isolation — transactions running at the same time don't interfere with each other's intermediate results. Durability — once a transaction is committed, it's permanently saved, even if the system crashes right after."

## How can a Deadlock happen at the database level?
"Same underlying idea as thread deadlocks — Transaction A locks Row 1 and wants Row 2, while Transaction B locks Row 2 and wants Row 1. Neither can proceed, and the database engine typically detects this and forcibly kills one of the transactions to break the deadlock, rolling it back."

**********************************************************************************************************************************
## ASP.NET Core MVC
--------------------------
Architecture & Core Concepts

##  What is MVC, and why is it structured that way?
"MVC stands for Model-View-Controller — it's a pattern that separates concerns. Model holds the data and business logic, View handles what the user sees (the HTML), and Controller sits in between, handling incoming requests and deciding what data to fetch and which View to show. The benefit is separation — a designer can work on Views without touching business logic, and you can change your data logic without breaking the UI."

##  What's Middleware in ASP.NET Core?
"Middleware is a piece of code that sits in the request pipeline — every incoming request passes through a chain of middleware components before reaching your controller, and the response passes back through them on the way out. Things like authentication, logging, error handling, and routing are all implemented as middleware. Order matters a lot — if you put authentication middleware after your routing middleware, it won't protect anything properly."

##  How does Dependency Injection work in ASP.NET Core specifically?
"It's built directly into the framework — you register your services (like IEmployeeRepository → SqlEmployeeRepository) in Program.cs, and then any controller or class can just ask for that interface in its constructor, and ASP.NET Core automatically provides the right implementation. This is the same DI concept from Day 4, just wired in by the framework instead of manually in Main."

##  What's the difference between Routing and Attribute Routing?
"Conventional routing defines URL patterns centrally, usually in Program.cs, like {controller}/{action}/{id} — matching URLs to controllers and actions by convention. Attribute Routing lets you define the route directly on the action method itself, like [Route("api/employees/{id}")] — giving you more explicit, fine-grained control per endpoint, which is especially common in Web APIs."

## Model, View, Controller, Razor

##  What's a Controller's actual job?
"It receives the incoming HTTP request, talks to the Model/business logic to get whatever data is needed, and then chooses which View to return, passing that data along. It shouldn't contain business logic itself — that belongs in a service or repository — the Controller is really just a traffic director."

##  What is Razor?
"Razor is the templating syntax ASP.NET Core uses to mix C# code with HTML inside View files (.cshtml). You write normal HTML, and wherever you need dynamic content, you use @ to drop into C#, like @foreach(var emp in Model) to loop through data and generate HTML for each item."

##  What are Tag Helpers?
"They're a Razor feature that lets you write HTML-like syntax that generates dynamic behavior server-side. Instead of manually writing a form action URL, you can write <form asp-action="Create"> and ASP.NET Core generates the correct URL for you automatically — cleaner and less error-prone than hardcoding paths."

## ViewBag, ViewData, TempData, Session, Cookies

##  What's the difference between ViewBag, ViewData, and TempData?
"ViewBag and ViewData both pass data from a Controller to a View for a single request — ViewBag is just a dynamic wrapper around ViewData, so they're functionally the same thing with different syntax. TempData is different — it persists data across one redirect, which is useful for something like showing a 'success' message after redirecting to a different action, since ViewBag/ViewData wouldn't survive that redirect."

##  What's the difference between Session and Cookies?
"Session data is stored server-side, and the client just holds a session ID to reference it — good for larger, sensitive data since it never actually leaves the server. Cookies are stored client-side, in the browser itself — better for smaller, less sensitive data, and they persist even across sessions if you set an expiration. If I'm storing something like a shopping cart temporarily, Session works well; if I want to remember a user's theme preference across visits, a Cookie makes more sense."

## Identity, Authentication, Authorization

##  What's the difference between Authentication and Authorization?
"Authentication answers 'who are you?' — verifying identity, like logging in with a username and password. Authorization answers 'what are you allowed to do?' — once you know who someone is, deciding whether they can access a specific resource or action, like whether they're an Admin versus a regular User."

##  What's ASP.NET Core Identity?
"It's the built-in framework for handling user accounts — registration, login, password hashing, roles, and more — so you don't have to build authentication from scratch. It handles the security-sensitive parts (like properly hashing passwords) correctly by default, which is important since rolling your own auth system is genuinely risky if done wrong."

## Model Validation, Filters, Logging

##  How does Model Validation work in ASP.NET Core?
"You add data annotations directly on your Model properties, like [Required] or [StringLength(50)], and the framework automatically checks incoming data against these rules before your Controller action even runs. In the Controller, you just check if (ModelState.IsValid) to see if validation passed."

##  What are Filters, and why not just put that logic directly in the Controller?
"Filters let you run code before or after a Controller action executes — for things like logging, authorization checks, or exception handling — without repeating that logic in every single action method. Instead of writing the same 'check if user is logged in' code in 20 different actions, you write an Authorization Filter once and just apply it wherever needed."

##  How do Logging and Exception Handling typically work together in ASP.NET Core?
"ASP.NET Core has built-in logging you inject via ILogger<T> into any class, letting you record what's happening at different severity levels (Info, Warning, Error). For handling exceptions globally instead of wrapping every action in try-catch, you typically use exception-handling middleware that catches unhandled exceptions anywhere in the pipeline, logs them, and returns a clean error response instead of leaking a stack trace to the user."

## Repository Pattern, Unit of Work, Entity Framework Core

##  What's Unit of Work, and how does it relate to Repository Pattern?
"Repository Pattern handles data access for one entity type at a time — like IEmployeeRepository. Unit of Work coordinates multiple repositories together as one single transaction — so if you're updating an Employee and also inserting a related record in another table, Unit of Work makes sure both either commit together or roll back together, rather than one succeeding and the other failing independently."

##  What is Entity Framework Core?
"It's an ORM — Object-Relational Mapper — that lets you work with database data using C# objects and LINQ instead of writing raw SQL. Instead of SELECT * FROM Employees WHERE Id = 1, you write context.Employees.Find(1), and EF Core translates that into SQL behind the scenes."

##  What are Migrations in EF Core?
"Migrations are a way to evolve your database schema over time, in sync with your C# model classes, without manually writing ALTER TABLE scripts. If you add a new property to your Employee class, you generate a migration, and EF Core figures out the SQL needed to update the actual database table to match — while keeping a version history of every schema change."

## CRUD, File Upload, Pagination, Searching, Sorting

##  What does CRUD mean in an ASP.NET Core MVC context?
"Create, Read, Update, Delete — the four basic operations any data-driven app needs. In MVC, this typically maps to Controller actions like Create, Index (read/list), Edit, and Delete, each with a corresponding View."

##  How does File Upload typically work in ASP.NET Core?
"You add an IFormFile parameter to your action method, which represents the uploaded file, then read its stream and save it to disk or cloud storage. The View side needs a form with enctype="multipart/form-data" for file uploads to actually transmit correctly — a very common thing to forget and then wonder why the file arrives as null."

##  How do Pagination, Searching, and Sorting typically get implemented together?
"All three usually combine in one query using LINQ — Where() for search filtering, OrderBy()/OrderByDescending() for sorting based on a column the user picked, then Skip() and Take() for pagination. The tricky part isn't the logic itself, it's designing the URL/query parameters cleanly so the current page, sort column, and search term all stay in sync as the user interacts with the page."

## JWT Basics

##  What is JWT, and why is it commonly used with APIs?
"JWT stands for JSON Web Token — it's a compact, self-contained way to represent a user's identity and claims (like their roles) as a signed token. Unlike traditional session-based auth where the server stores session state, JWT is stateless — the server just verifies the token's signature on each request, without needing to look anything up in a session store. This makes it a natural fit for APIs, especially ones consumed by mobile apps or single-page applications, where you don't want the server tracking session state for every client."

##  What's actually inside a JWT?
"Three parts, separated by dots: a Header (specifies the signing algorithm), a Payload (the actual claims — like user ID, roles, expiration time), and a Signature (verifies the token hasn't been tampered with). Importantly, the payload is just Base64-encoded, not encrypted — so you should never put sensitive data like passwords directly inside a JWT, since anyone can decode and read it, they just can't modify it without invalidating the signature."