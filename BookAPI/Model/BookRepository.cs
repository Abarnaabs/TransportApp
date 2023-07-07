namespace BookAPI.Model
{
    public interface IBookRepository
    {
        void AddBook(BookClass book);
        BookClass GetBook(string bookName);
        List<BookClass> GetAllBooks();
        void DeleteBook(string bookName);
    }
    public class BookRepository : IBookRepository
    {
        private List<BookClass> books=new List<BookClass>()
        {
            new BookClass(){BookId=12,Name="It ends with us",Author="Collen",Publisher="XY publication",Price=120},
            new BookClass(){BookId=131,Name="Tempataion",Author="Sally",Publisher="YX Publication",Price=100}
        };
        public void AddBook(BookClass book)
        {
            books.Add(book);
        }

        public void DeleteBook(string bookName)
        {
            try
            {
                BookClass book = GetBook(bookName);
                books.Remove(book);
            }
            catch(Exception) { throw; }
        }

        public List<BookClass> GetAllBooks()
        {
            try
            {
                return books;
            }
            catch(Exception) { throw; }
        }

        public BookClass? GetBook(string name)
        {
            try
            {
                return books.SingleOrDefault(BookClass => BookClass.Name == name);
            }
            catch(Exception) { throw; }
        }
    }
}
