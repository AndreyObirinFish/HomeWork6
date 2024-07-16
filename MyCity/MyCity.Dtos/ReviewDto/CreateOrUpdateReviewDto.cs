using System.ComponentModel.DataAnnotations;

namespace MyCity.Dtos.ReviewDto
{
    public class CreateOrUpdateReviewDto
    {
        [MaxLength(1000)]
        public required string Text { get; set; }
    
        [Range(0, 5)]
        public int Rating { get; set; }
    }
}
