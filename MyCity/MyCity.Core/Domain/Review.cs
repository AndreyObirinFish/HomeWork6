using System.ComponentModel.DataAnnotations;

namespace MyCity.Core.Domain;

public class Review : BaseEntity
{
    [MaxLength(1000)]
    public required string Text { get; set; }
    
    [Range(0, 5)]
    public int Rating { get; set; }
}