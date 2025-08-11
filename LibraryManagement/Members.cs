using System;
using System.Collections.Generic;

public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();

    public abstract void BorrowBook(Book book);
    public abstract void ReturnBook(Book book);
}

public class Student : User
{
    private const int MaxBooks = 3;

    public override void BorrowBook(Book book)
    {
        if (BorrowedBooks.Count >= MaxBooks)
            throw new LimitReachedException($"{Name} has reached the borrowing limit.");

        if (!book.TryBorrow(this))
            throw new Exception($"Book '{book.Title}' is already borrowed.");

        BorrowedBooks.Add(book);
    }

    public override void ReturnBook(Book book)
    {
        if (BorrowedBooks.Remove(book))
        {
            book.Return();
        }
        else
        {
            throw new Exception($"{Name} did not borrow the book '{book.Title}'.");
        }
    }
}

public class Faculty : User
{
    private const int MaxBooks = 5;

    public override void BorrowBook(Book book)
    {
        if (BorrowedBooks.Count >= MaxBooks)
            throw new LimitReachedException($"{Name} has reached the borrowing limit.");

        if (!book.TryBorrow(this))
            throw new Exception($"Book '{book.Title}' is already borrowed.");

        BorrowedBooks.Add(book);
    }

    public override void ReturnBook(Book book)
    {
        if (BorrowedBooks.Remove(book))
        {
            book.Return();
        }
        else
        {
            throw new Exception($"{Name} did not borrow the book '{book.Title}'.");
        }
    }
}
