using System.ComponentModel.DataAnnotations;

namespace Library.DTO
{
    public class RateBookDTO
    {
        [Range(1, 5, ErrorMessage = "Score must be between 1 and 5.")]
        public int Score { get; set; }
    }
}
