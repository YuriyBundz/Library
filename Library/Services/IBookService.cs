using Library.DTO;

namespace Library.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooks(string orderBy);
        Task<IEnumerable<RecommendedBookDTO>> GetRecommendedBooks(string genre);
        Task<BookDetailsDTO> GetBookDetails(int bookId);
        Task<int> DeleteBook(int bookId);
        Task<int> SaveBook(NewBookDTO newBookDTO);
        Task<int> SaveReview(int bookId, NewReviewDTO newReviewDTO);
        Task<int> RateBook(int bookId, RateBookDTO rateBookDTO);
    }

}
