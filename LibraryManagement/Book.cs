public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    private bool isAvailable = true;
    public bool IsAvailable => isAvailable;
    public User BorrowedBy { get; private set; }

    public bool TryBorrow(User user)
    {
        if (!isAvailable) return false;

        isAvailable = false;
        BorrowedBy = user;
        return true;
    }

    public void Return()
    {
        isAvailable = true;
        BorrowedBy = null;
    }
}
