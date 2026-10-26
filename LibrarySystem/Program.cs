namespace LibrarySystem;

public class Loan
{
    public Loan(Member member, DateTime returnDate) => (Member, ReturnDate) = (member, returnDate);
    public DateTime ReturnDate { get; }
    public Member Member { get; }
}

public class Book
{
    public int Id { get; }
    public string Name { get; }
    public int Location { get; }
    public Loan? Loan { get; }
    public Book(int id, string name, int location) => (Id, Name, Location) = (id, name, location);

    public void Borrow(Loan loan) => Loan = loan;
    public void Return() => Loan = null;
    public bool IsBorrowed() => Loan != null;
}

public class Member
{
    public int Id { get; }
    public string Name { get; }
    public Member(int id, string name) => (Id, Name) = (id, name);
}

public class Library
{
    public List<Book> _books;

    public Library(List<Book> books) => _books = books;

    public int SearchBook(string bookName)
    {
        var book = _books.FirstOrDefault(x => x.Name == bookName);

        if (book.IsBorrowed()) throw Exception("The book is borrowed");

        return book.Location;
    }

    public void Borrow(List<Book> books, Member member, DateTime returnDate)
    {
        foreach (var book in books)
        {
            book.Borrow(new BookBorrow(member, returnDate));
        }
    }

    public void Return(List<Book> books)
    {
        foreach (var book in books)
        {
            book.Return();
        }
    }

    public BookBorrow BorrowedList(string bookName)
    {
        var book = _books.FirstOrDefault(x => x.Name == bookName);

        return book.Loan;
    }
}