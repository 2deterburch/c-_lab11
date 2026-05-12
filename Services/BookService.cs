using Microsoft.EntityFrameworkCore;
using pr11.Models;

namespace pr11.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books
                .Include(b => b.Author)
                .ToList();
        }

        public Book? GetBookById(int id)
        {
            return _context.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);
        }

        public Book AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public bool DeleteBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return false;

            _context.Books.Remove(book);
            _context.SaveChanges();

            return true;
        }
    }
}