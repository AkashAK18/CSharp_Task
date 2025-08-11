using System;

class Program
{
    static void Main()
    {
        Library library = new Library();

        // Subscribe to events
        library.BookUnavailable += book =>
        {
            Console.WriteLine($"Book '{book.Title}' is now unavailable.");
        };

        library.BorrowLimitReached += user =>
        {
            Console.WriteLine($"{user.Name} - Borrow limit reached.");
        };

        // Add sample users
        library.AddUser(new Student { Id = 1, Name = "Amit" });
        library.AddUser(new Student { Id = 2, Name = "Priya" });
        library.AddUser(new Faculty { Id = 3, Name = "Ramesh" });

        // Add sample books
        library.AddBook(new Book { BookId = 101, Title = "Wings of Fire", Author = "A.P.J. Abdul Kalam" });
        library.AddBook(new Book { BookId = 102, Title = "Gitanjali", Author = "Rabindranath Tagore" });
        library.AddBook(new Book { BookId = 103, Title = "Godaan", Author = "Munshi Premchand" });
        library.AddBook(new Book { BookId = 104, Title = "The Discovery of India", Author = "Jawaharlal Nehru" });
        library.AddBook(new Book { BookId = 105, Title = "Train to Pakistan", Author = "Khushwant Singh" });

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nLibrary Management Menu:");
            Console.WriteLine("1. Borrow Book");
            Console.WriteLine("2. Return Book");
            Console.WriteLine("3. List Available Books");
            Console.WriteLine("4. List Borrowed Books");
            Console.WriteLine("5. View Borrowed Books by User");
            Console.WriteLine("6. Filter Books by Title");
            Console.WriteLine("7. Group Books by Author");
            Console.WriteLine("8. Library Report");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option (1-8) for Exit(0): ");

            string input = Console.ReadLine();
            Console.WriteLine();

            if (input == "1")
            {
                Console.Write("Enter User ID: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Enter Book ID: ");
                int bookId = int.Parse(Console.ReadLine());
                library.BorrowBook(userId, bookId);
            }
            else if (input == "2")
            {
                Console.Write("Enter User ID: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Enter Book ID: ");
                int bookId = int.Parse(Console.ReadLine());
                library.ReturnBook(userId, bookId);
            }
            else if (input == "3")
            {
                library.ListAvailableBooks();
            }
            else if (input == "4")
            {
                library.ListBorrowedBooks();
            }
            else if (input == "5")
            {
                Console.Write("Enter User ID: ");
                int userId = int.Parse(Console.ReadLine());
                library.GetBorrowedBooksByUser(userId);
            }
            else if (input == "6")
            {
                Console.Write("Enter keyword to search in titles: ");
                string keyword = Console.ReadLine();
                library.FilterBooks(keyword);
            }
            else if (input == "7")
            {
                library.GroupBooksByAuthor();
            }
            else if (input == "8")
            {
                library.Report();
            }
            else if (input == "0")
            {
                running = false;
                Console.WriteLine("Exiting the program.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
            }
        }
    }
}
