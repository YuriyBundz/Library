namespace Library.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public double Score { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
