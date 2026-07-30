using System.Collections.Generic;

class Book
{
    public string Title;
    public string Author;
    public bool IsIssued;

    public Book(string title,string author)
    {
        Title=title;
        Author=author;
        IsIssued = false;
    }
}

class Library
{
    private List<Book> books=new List<Book>();
    public void AddBook(string title,string author)
    {
        books.Add(new Book(title ,author));
        Console.WriteLine($"Added book: {title}");
    }

    public void IssurBook(string title)
    {
        Book book = books.Find(b => b.Title == title);
        if(book == null)
        {
            Console.WriteLine($"{title} not found in library.");
        }
        else if (book.IsIssued)
        {
            Console.WriteLine($"{title} is already issued.");
        }
        else
        {
            Console.WriteLine($"{title} issued successfully.");
        }
    }

    public void ReturnBook(string title)
    {
        Book book = books.Find(b => b.Title ==title);
        if(book == null)
        {
            Console.WriteLine($"{title} not found in library. ");
        }
        else if (!book.IsIssued)
        {
            Console.WriteLine($"{title} was not issued.");
        }
        else
        {
            book.IsIssued =false;
            Console.WriteLine($"{title } retruned successfully.");
        }
    }

    public void ShowAvailableBooks()
    {
        Console.WriteLine("\n -- Available Books --");
        foreach(var book in books)
        {
            if (!book.IsIssued)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
    }

    public void ShowAllBooks()
    {
        Console.WriteLine("\n -- All Books --");
        foreach(var book in books)
        {
            string status = book.IsIssued? "Issued": "Available";
            Console.WriteLine($"{book.Title} by {book.Author} - {status}");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new  Library();

        library.AddBook("Clean Code","Robert Martin");
        library.AddBook("C# in Depth","Jon Skeet");

        library.ShowAllBooks();

        library.IssurBook("Clean Code");
        library.IssurBook("Cleam Code"); //should failed - already issued

        library.ShowAvailableBooks();

        library.ReturnBook("Clean Code");
        library.ShowAllBooks();
    }
}