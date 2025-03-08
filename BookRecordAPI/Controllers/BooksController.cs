using Microsoft.AspNetCore.Mvc;
using BookRecordAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookRecordAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Genre = "Dystopian", PublishedYear = 1949 },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", PublishedYear = 1960 }
        };

        // GET: api/books
        /*
         ActionResult<IEnumerable<Book>>: This is the return type of the method. It means:

        The method will return an HTTP response (ActionResult).

        The response will contain a list of books (IEnumerable<Book>).
        */

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(books);
        }

        // GET: api/books/{id}
        /*
         searches for book in books list using id,book is returned if found 
        else not found returned
         
         */
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { message = "Book not found" });

            return Ok(book);
        }

        // POST: api/books
        /*
         [FromBody] Book book: This tells ASP.NET Core to get the book object from the request body.
         */
        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            if (books.Any(b => b.Id == book.Id))
                return BadRequest(new { message = "Book with this ID already exists" });

            books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        /*
         [FromBody] Book updatedBook: This tells ASP.NET Core to get the updatedBook object from the request body.
         */
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { message = "Book not found" });

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            book.PublishedYear = updatedBook.PublishedYear;

            return NoContent();
        }

        // PATCH: api/books/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchBook(int id, [FromBody] Dictionary<string, object> updates)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { message = "Book not found" });

            foreach (var key in updates.Keys)
            {
                switch (key.ToLower())
                {
                    case "title":
                        book.Title = updates[key].ToString();
                        break;
                    case "author":
                        book.Author = updates[key].ToString();
                        break;
                    case "genre":
                        book.Genre = updates[key].ToString();
                        break;
                    case "publishedyear":
                        if (int.TryParse(updates[key].ToString(), out int year))
                            book.PublishedYear = year;
                        break;
                }
            }
            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { message = "Book not found" });

            books.Remove(book);
            return NoContent();
        }
    }
}
