using System.ComponentModel.DataAnnotations;

namespace MyCity.WebHost.Models
{
    public class CreateOrUpdateReviewRequest
    {
        [MaxLength(1000)]
        public required string Text { get; set; }
    
        [Range(0, 5)]
        public int Rating { get; set; }
    }
}
