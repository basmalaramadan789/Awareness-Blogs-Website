using System.ComponentModel.DataAnnotations.Schema;

namespace AwarenessWebsite.Models;

public class Content
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }  

    public Category Category { get; set; }
    public string TargetAgeGroup { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
    public string ImagePath { get; set; } =string.Empty;

    
    public ICollection<Recommendation>? Recommendations { get; set; }
    public ICollection<Feedback>? Feedbacks { get; set; }
    public ICollection<Bookmark>? Bookmarks { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
}
