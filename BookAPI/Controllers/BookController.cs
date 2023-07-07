using BookAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookRepository _bookRepository;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = new BookRepository();
        }
        [HttpGet,Route("GetAllBooks/{bookName}")]
        public IActionResult GetAllBooks(string bookName)
        {
            try
            {
                List<BookClass> book = _bookRepository.GetAllBooks();
                return StatusCode(200, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet,Route("GetBook/{bookName}")]
        public IActionResult GetBook(string bookName)
        {
            try
            {
                BookClass book = _bookRepository.GetBook(bookName);
                if (book != null)
                    return StatusCode(200, book);
                else
                    return StatusCode(500, "Book Not found");
            }
            catch(Exception ex) { return StatusCode(500, ex);}

        }
        [HttpPost,Route("AddBook")]
        public IActionResult AddBook(BookClass book)
        {
            try
            {
                _bookRepository.AddBook(book);
                return StatusCode(200, book);   
            }
            catch(Exception ex) { return StatusCode(500, ex);}
        }
        [HttpDelete,Route("DeleteBook/{bookName}")]
        public IActionResult DeleteBook(string bookName)
        {
            try
            {
                _bookRepository.DeleteBook(bookName);
                return StatusCode(200, $"{bookName} is deleted");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
