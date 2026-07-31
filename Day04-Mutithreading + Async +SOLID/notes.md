## Multithreading — Theory

# What's a Thread, in plain terms?
"A thread is a single path of execution within a program. By default, your program runs on one thread — one instruction after another. Multithreading means running multiple paths of execution at the same time, so your program can do more than one thing simultaneously."

# What's the difference between Thread and Task?
"Thread is the low-level, raw way of creating a new path of execution — you manage its whole lifecycle yourself. Task is a higher-level abstraction built on top of the thread pool — it's easier to work with, handles a lot of the complexity for you, and is what modern C# code actually uses almost all the time. I'd reach for Task in virtually every real scenario; raw Thread is rare outside very specific low-level needs."

# What does Task.Run actually do?
"It queues a piece of work to run on a background thread from the thread pool, and immediately gives you back a Task object representing that work — so your main thread isn't blocked waiting for it to finish."

# What does Task.Wait do, and why should you be careful with it?
"It blocks the current thread until the task finishes. The danger is it defeats the whole purpose of async work — if I call .Wait() on the main thread, I've turned my asynchronous code back into synchronous, blocking code. In UI applications, this can even freeze the interface. It's mostly a red flag when you see it in real code."

# Explain async and await like I'm new to this.
"async marks a method as one that can run asynchronously — it doesn't run on a separate thread by itself, it just means the method can pause and resume. await is what actually pauses execution at that point, without blocking the thread, until whatever it's awaiting (usually a Task) finishes. While it's paused, the thread is free to go do other work — that's the whole benefit. It's very different from Task.Wait, which blocks instead of freeing the thread."

# What's Parallel.For?
"It's a way to run a for loop's iterations in parallel, across multiple threads, instead of one after another. If I have 10,000 independent calculations to do and they don't depend on each other, Parallel.For can split that work across CPU cores automatically. I'd only use it when the iterations truly don't depend on shared state — otherwise you risk race conditions."

# What's a Cancellation Token for?
"It's a clean way to tell a running task 'stop what you're doing.' Instead of forcibly killing a thread (which is dangerous and can leave things in a broken state), you pass a CancellationToken into the task, and the task itself periodically checks 'has cancellation been requested?' and exits gracefully if so."

# What's a Race Condition?
"It's when two or more threads access and modify shared data at the same time, and the final result depends on unpredictable timing — literally which thread happens to 'win the race.' Classic example: two threads both read a bank balance of 100, both add 50, both write back 150 — but the real answer should've been 200, because one update got lost."

# How do lock, Mutex, and Semaphore relate to race conditions?
"They're all ways to prevent race conditions by controlling access to shared resources. lock is the simplest — it ensures only one thread at a time can execute a block of code, within a single process. Mutex does basically the same thing but can work across multiple processes, not just within one program. Semaphore is more flexible — instead of allowing only one thread at a time, it allows a specific number of threads at once, like letting 3 threads through a door instead of just 1."

# What's a Deadlock?
"It's when two or more threads are stuck waiting on each other forever, and neither can proceed. Classic example: Thread A holds Lock 1 and is waiting for Lock 2, while Thread B holds Lock 2 and is waiting for Lock 1 — neither will ever release what the other needs, so both freeze permanently."

# What's the Thread Pool?
"Rather than creating a brand new thread every time you need one — which is expensive — the Thread Pool keeps a reusable pool of worker threads ready to go. When you use Task.Run, it's actually pulling a thread from this pool instead of creating one from scratch, which is much more efficient."

## SOLID Principles

# What does SOLID stand for, and why does it matter?
"It's five design principles that make code easier to maintain, extend, and test over time. Each letter is one principle. They're not strict rules you must follow 100% of the time, but they're a strong default mindset for writing clean, flexible code — especially in larger codebases where bad design compounds into real pain."

# What's the Single Responsibility Principle?
"A class should have exactly one reason to change. If my Employee class handles employee data AND sends emails AND writes to a database, that's three separate responsibilities crammed into one class — a change to email logic could accidentally break something related to data. Instead, I'd split those into Employee, EmailService, and EmployeeRepository, each with one clear job."

# What's the Open/Closed Principle?
"Classes should be open for extension, but closed for modification. That means I should be able to add new behavior without changing existing, already-tested code. The classic way to achieve this is through abstraction — like an interface or base class — where new functionality comes from adding a new derived class, not editing the old one. Your Shape/Circle/Rectangle setup from Day 2 actually follows this: adding a Triangle didn't require touching Circle or Rectangle at all."

# What's the Liskov Substitution Principle?
"Any subclass should be usable wherever its parent class is expected, without breaking the program. The classic violation example is a Square inheriting from Rectangle — mathematically a square IS a rectangle, but if Rectangle has separate SetWidth/SetHeight methods, a Square can't honor both independently without breaking the expected behavior. If substituting a subclass changes how the program should behave in unexpected ways, that's a Liskov violation."

# What's the Interface Segregation Principle?
"Don't force a class to implement methods it doesn't actually need. If I have one big IWorker interface with Work() and Eat(), but I create a RobotWorker that doesn't eat, I've forced it to implement a meaningless Eat() method. Better to split into smaller, focused interfaces — IWorkable and IFeedable — so classes only implement what's actually relevant to them."

# What's the Dependency Inversion Principle?
"High-level code shouldn't depend directly on low-level, concrete implementations — both should depend on abstractions instead. Like, instead of my OrderService directly creating a SqlDatabase instance internally, it should depend on an IDatabase interface, and the actual SqlDatabase gets passed in from outside. This is exactly what makes Dependency Injection possible — it's the principle, DI is the practical technique that applies it."

## Design Patterns

# What's the Singleton pattern?
"It ensures a class has exactly one instance throughout the entire application, and gives you one global access point to it. Common use case: a configuration manager or a logging service — you don't want 10 different instances all managing separate config data, you want everyone in the app sharing the same one."

# What's the Repository pattern?
"It's a layer that sits between your business logic and your actual data source — like a database. Instead of scattering SQL queries or Entity Framework calls throughout your code, you centralize all data access behind something like IEmployeeRepository with methods like GetById, Add, Delete. The benefit is your business logic doesn't care whether data comes from SQL Server, an API, or an in-memory list — and it makes testing much easier since you can swap in a fake repository."

# What's the Factory pattern?
"It's a way to centralize object creation logic instead of scattering new SomeClass() calls everywhere. If creating an object involves some decision-making — like 'which type of Shape should I create based on user input?' — a Factory method handles that decision in one place, so the rest of your code just asks the factory for what it needs without knowing the creation details."

# What's Dependency Injection, and how does it relate to Dependency Inversion?
"Dependency Inversion is the principle — depend on abstractions, not concrete classes. Dependency Injection is the actual technique that makes that happen in practice — instead of a class creating its own dependencies internally, they get 'injected' from outside, usually through the constructor. Like passing an IEmployeeRepository into a service's constructor rather than the service creating a SqlEmployeeRepository itself. This is huge for testability — you can inject a fake repository during unit tests instead of hitting a real database."