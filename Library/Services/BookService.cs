using AutoMapper;
using Library.DTO;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly LibraryContext _context;

        public BookService(IMapper mapper, LibraryContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> DeleteBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
            {
                return 0;
            }

            _context.Books.Remove(book);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooks(string orderBy)
        {
            IQueryable<Book> query = _context.Books.Include(b => b.Reviews).Include(b => b.Ratings);

            switch (orderBy)
            {
                case "title":
                    query = query.OrderBy(b => b.Title);
                    break;
                case "author":
                    query = query.OrderBy(b => b.Author);
                    break;
                case "genre":
                    query = query.OrderBy(b => b.Genre);
                    break;
                default:
                    query = query.OrderBy(b => b.Id);
                    break;
            }

            var books = await query.ToListAsync();

            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDetailsDTO> GetBookDetails(int bookId)
        {
            var book = await _context.Books.Where(c => c.Id == bookId).Include(x => x.Ratings)
                .Include(a => a.Reviews).SingleOrDefaultAsync();

            if (book == null)
            {
                return null;
            }

            var bookDetailsDTO = _mapper.Map<BookDetailsDTO>(book);

            return bookDetailsDTO;
        }

        public async Task<IEnumerable<RecommendedBookDTO>> GetRecommendedBooks(string genre)
        {
            var books = await _context.Books.Where(b => b.Genre == genre && b.Reviews.Count > 1)
               .OrderByDescending(b => b.Ratings.Average(r=>r.Score)).Take(10).ToListAsync();

            if (books.Count == 0)
            {
                //Response.StatusCode = 404;
            }

            var recommendedBookDTO = _mapper.Map<IEnumerable<RecommendedBookDTO>>(books);

            return recommendedBookDTO;
        }

        public async Task<int> RateBook(int bookId, RateBookDTO rateBookDTO)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
            {
                return 0;
            }

            var rating = new Rating
            {
                Score = rateBookDTO.Score,
                BookId = bookId
            };

            _context.Ratings.Add(rating);

            await _context.SaveChangesAsync();

            return rating.Id;
        }

        public async Task<int> SaveBook(NewBookDTO newBookDTO)
        {
            var book = _mapper.Map<Book>(newBookDTO);

            if (book.Id == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
                _context.Books.Update(book);
            }

            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<int> SaveReview(int bookId, NewReviewDTO newReviewDTO)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
            {
                return 0;
            }

            var review = _mapper.Map<Review>(newReviewDTO);

            book.Reviews.Add(review);

            await _context.SaveChangesAsync();

            return review.Id;
        }
    }
}
