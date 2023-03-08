using AutoMapper;
using Library.DTO;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Net;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IConfiguration _config;

        public BooksController(IBookService bookService, IConfiguration config)
        {
            _bookService = bookService;
            _config = config;
        }

        // 1. Get all books. Order by provided value (title or author)
        [HttpGet("api/books")]
        public async Task<ActionResult<List<BookDTO>>> GetAllBooks([FromQuery] string order)
        {
            var books = await _bookService.GetAllBooks(order);
            return Ok(books);
        }

        // 2. Get top 10 books with high rating and number of reviews greater than 10. You can filter books by specifying genre. Order by rating
        [HttpGet("api/recommended")]
        public async Task<ActionResult<List<BookDTO>>> GetRecommendedBooks([FromQuery] string genre)
        {
            var books = await _bookService.GetRecommendedBooks(genre);
            return Ok(books);
        }

        // 3. Get book details with the list of reviews
        [HttpGet("api/books/{id}")]
        public async Task<ActionResult<BookDetailsDTO>> GetBookDetails(int id)
        {
            var bookDetails = await _bookService.GetBookDetails(id);
            return Ok(bookDetails);
        }

        // 4. Delete a book using a secret key. Save the secret key in the config of your application. Compare this key with a query param
        [HttpDelete("api/books/{id}")]
        public async Task<IActionResult> DeleteBook(int id, [FromQuery] string secret)
        {
            string secretKey = _config.GetValue<string>("SecretKey");
            if (secret != secretKey)
            {
                return Unauthorized();
            }

            var result = await _bookService.DeleteBook(id);

            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        // 5. Save a new book.
        [HttpPost("api/books/save")]
        public async Task<ActionResult<int>> SaveBook([FromBody] NewBookDTO newBookDTO)
        {
            var bookId = await _bookService.SaveBook(newBookDTO);
            return Ok(bookId);
        }

        // 6. Save a review for the book.
        [HttpPut("api/books/{id}/review")]
        public async Task<ActionResult<int>> SaveReview(int id, [FromBody] NewReviewDTO newReviewDTO)
        {
            var reviewId = await _bookService.SaveReview(id, newReviewDTO);
            return Ok(reviewId);
        }

        // 7. Rate a book
        [HttpPut("api/books/{id}/rate")]
        public async Task<IActionResult> RateBook(int id, [FromBody] RateBookDTO rateBookDTO)
        {
            await _bookService.RateBook(id, rateBookDTO);
            return NoContent();
        }
    }
}

