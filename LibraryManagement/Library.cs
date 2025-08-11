using System;
using System.Collections.Generic;
using System.Linq;

public class Library
{
    public List<User> Users { get; set; } = new List<User>();
    public List<Book> Books { get; set; } = new List<Book>();

    public delegate void BookUnavailableHandler(Book book);
    public event BookUnavailableHandler BookUnavailable;

    public delegate void BorrowLimitReachedHandler(User user);
    public event BorrowLimitReachedHandler BorrowLimitReached;

    public void AddUser(User user) => Users.Add(user);
    public void AddBook(Book book) => Books.Add(book);

    public void BorrowBook(int userId, int bookId)
    {
        var user = Users.FirstOrDefault(u => u.Id == userId);
        var book = Books.FirstOrDefault(b => b.BookId == bookId);

        if (user == null || book == null)
        {
            Console.WriteLine("User or Book not found.");
            return;
        }

        try
        {
            user.BorrowBook(book);
            if (!book.IsAvailable)
                BookUnavailable?.Invoke(book);
        }
        catch (LimitReachedException ex)
        {
            BorrowLimitReached?.Invoke(user);
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ReturnBook(int userId, int bookId)
    {
        var user = Users.FirstOrDefault(u => u.Id == userId);
        var book = Books.FirstOrDefault(b => b.BookId == bookId);

        if (user == null || book == null)
        {
            Console.WriteLine("User or Book not found.");
            return;
        }

        try
        {
            user.ReturnBook(book);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ListAvailableBooks()
    {
        Console.WriteLine("\nAvailable Books:");
        foreach (var b in Books.Where(b => b.IsAvailable))
            Console.WriteLine($"- {b.Title} by {b.Author}");
    }

    public void ListBorrowedBooks()
    {
        Console.WriteLine("\nBorrowed Books:");
        foreach (var b in Books.Where(b => !b.IsAvailable))
            Console.WriteLine($"- {b.Title} by {b.Author}, Borrowed by: {b.BorrowedBy.Name}");
    }

    public void GetBorrowedBooksByUser(int userId)
    {
        var user = Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine($"\nBooks borrowed by {user.Name}:");
        foreach (var b in user.BorrowedBooks)
            Console.WriteLine($"{b.Title} by {b.Author}");
    }

    public void GroupBooksByAuthor()
    {
        Console.WriteLine("\nBooks Grouped by Author:");
        var groups = Books.GroupBy(b => b.Author);
        foreach (var group in groups)
        {
            Console.WriteLine($"Author: {group.Key}");
            foreach (var book in group)
                Console.WriteLine($" - {book.Title}");
        }
    }

    public void FilterBooks(string keyword)
    {
        Console.WriteLine($"\nSearch Results for '{keyword}':");
        var filtered = Books.Where(b =>
            b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        foreach (var b in filtered)
            Console.WriteLine($"{b.Title} by {b.Author}");
    }

    public void Report()
    {
        Console.WriteLine("\nLibrary Report:");
        Console.WriteLine($"Total Books: {Books.Count}");
        Console.WriteLine($"Borrowed Books: {Books.Count(b => !b.IsAvailable)}");
        Console.WriteLine($"Available Books: {Books.Count(b => b.IsAvailable)}");

        var topUsers = Users.OrderByDescending(u => u.BorrowedBooks.Count).Take(3);
        Console.WriteLine("Top 3 Users by Borrow Count:");
        foreach (var u in topUsers)
            Console.WriteLine($" - {u.Name}: {u.BorrowedBooks.Count} books");
    }
}
