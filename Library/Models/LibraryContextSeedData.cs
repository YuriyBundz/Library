using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContextSeedData
    {
        private readonly LibraryContext _context;

        public LibraryContextSeedData(LibraryContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            // Add seed data to the context here
            // Example:
            if (!_context.Books.Any())
            {
                _context.Books.Add(new Book
                {
                    Id = 1,
                    Title = "To Kill a Mockingbird",
                    Cover = "https://covers.openlibrary.org/w/id/8413960-M.jpg",
                    Content = "Some content To Kill a Mockingbird",
                    Genre = "Classic",
                    Author = "Harper Lee",
                    Ratings = new List<Rating>
                        {
                            new Rating { Score = 4.5 },
                            new Rating { Score = 5 }
                        },
                    Reviews = new List<Review>
                        {
                            new Review { Message = "A true masterpiece", Reviewer = "John" },
                            new Review { Message = "One of the best books I've ever read", Reviewer = "Mary" }
                         }
                });
                //_context.Ratings.Add(new Rating { Score = 4.5, BookId = 1});
                _context.Books.Add(new Book
                {
                    Id = 2,
                    Title = "1984",
                    Cover = "https://covers.openlibrary.org/w/id/7222246-M.jpg",
                    Content = "Some content 1984",
                    Genre = "Dystopian",
                    Author = "George Orwell",
                    Ratings = new List<Rating>
                         {
                            new Rating { Score = 4 },
                            new Rating { Score = 4.5 }
                         },
                    Reviews = new List<Review>
                         {
                            new Review { Message = "A haunting vision of the future", Reviewer = "Adam" },
                            new Review { Message = "Orwell's masterpiece", Reviewer = "Sarah" }
                         }
                });
                _context.Books.Add(new Book
                {
                    Id = 3,
                    Title = "The Great Gatsby",
                    Cover = "https://covers.openlibrary.org/w/id/7222248-M.jpg",
                    Content = "In the summer of 1922, Nick Carraway moves from the Midwest to New York City to become a bond salesman.",
                    Genre = "Fiction",
                    Author = "F. Scott Fitzgerald",
                    Reviews = new List<Review>{
                         new Review { Message = "A thrilling read!", Reviewer = "John" },
                         new Review { Message = "Couldn't put it down!", Reviewer = "Emily" }},
                    Ratings = new List<Rating>
                         {
                            new Rating { Score = new Random().NextDouble() * 5 },
                            new Rating { Score = new Random().NextDouble() * 5 }
                         }
                });
                _context.Books.Add(new Book
                {
                    Id = 4,
                    Title = "Pride and Prejudice",
                    Cover = "https://covers.openlibrary.org/w/id/7222245-M.jpg",
                    Content = "Pride and Prejudice is a novel of manners by Jane Austen, first published in 1813.",
                    Genre = "Romance",
                    Author = "Jane Austen",
                    Reviews = new List<Review>{
                         new Review { Message = "A must-read for anyone who loves historical fiction", Reviewer = "Rachel" },
                         new Review { Message = "A true page-turner!", Reviewer = "Jack" }},
                    Ratings = new List<Rating>
                         {
                            new Rating { Score = new Random().NextDouble() * 5 },
                            new Rating { Score = new Random().NextDouble() * 5 }
                         }
                });
                _context.Books.Add(new Book
                {
                    Id = 5,
                    Title = "One Hundred Years of Solitude",
                    Cover = "https://covers.openlibrary.org/w/id/7222247-M.jpg",
                    Content = "One Hundred Years of Solitude is a landmark 1967 novel by Colombian author Gabriel García Márquez.",
                    Genre = "Magical Realism",
                    Author = "Gabriel García Márquez",
                    Reviews = new List<Review>{
                         new Review { Message = "Absolutely mesmerizing!", Reviewer = "Sophia" },
                         new Review { Message = "I can't recommend this book enough", Reviewer = "Isabella" },
                         new Review { Message = "The characters were so well-developed and realistic", Reviewer = "David" }},

                    Ratings = new List<Rating>
                         {
                            new Rating { Score = new Random().NextDouble() * 5 },
                            new Rating { Score = new Random().NextDouble() * 5 }
                         }
                });
                _context.Books.Add(new Book
                {
                    Id = 6,
                    Title = "The Catcher in the Rye",
                    Cover = "https://covers.openlibrary.org/w/id/7222249-M.jpg",
                    Content = "The Catcher in the Rye is a novel by J. D. Salinger, partially published in serial form in 1945–1946 and as a novel in 1951.",
                    Genre = "Fantasy",
                    Author = "J. D. Salinger",
                    Reviews = new List<Review>{
                         new Review { Message = "An emotional rollercoaster", Reviewer = "Daniel" },
                         new Review { Message = "A gripping thriller that kept me on the edge of my seat", Reviewer = "Lila" }},
                    Ratings = new List<Rating>
                         {
                            new Rating { Score = new Random().NextDouble() * 5 },
                            new Rating { Score = new Random().NextDouble() * 5 }
                         }
                });
                _context.Books.Add(new Book
                {
                    Id = 7,
                    Title = "The Hobbit",
                    Cover = "https://covers.openlibrary.org/w/id/6979865-M.jpg",
                    Content = "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien.",
                    Genre = "Fantasy",
                    Author = "J. R. R. Tolkien",
                    Reviews = new List<Review>{
                         new Review { Message = "I laughed, I cried, I loved every minute of it", Reviewer = "Olivia" },
                         new Review { Message = "This book exceeded all my expectations", Reviewer = "Samuel" }},
                    Ratings = new List<Rating>
                         {
                            new Rating { Score = new Random().NextDouble() * 5 },
                            new Rating { Score = new Random().NextDouble() * 5 }
                         }
                });
                _context.SaveChanges();
            }
        }
    }

}

//"A beautiful and thought-provoking novel", reviewed by "Nathan"
//"The writing was simply breathtaking", reviewed by "Emma"
//"A powerful story that will stay with you long after you finish reading", reviewed by "Ava"
//"One of the best books I've ever read", reviewed by "William"
//"I was completely immersed in the world of the book", reviewed by "Grace"
//"The plot twists were so unexpected and well-done", reviewed by "Ethan"
//"A moving and inspiring story", reviewed by "Mia"
//"I couldn't stop thinking about the characters even after finishing the book", reviewed by "Jacob"
//"An unforgettable read", reviewed by "Chloe"
//"The writing was so vivid, I felt like I was living the story myself", reviewed by "Benjamin"
//"A truly remarkable book", reviewed by "Elizabeth"