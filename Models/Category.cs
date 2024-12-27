using System.ComponentModel.DataAnnotations.Schema;

namespace AwarenessWebsite.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } =string.Empty;

  
    public ICollection<Content>? Contents { get; set; }
    [NotMapped]
    public double AverageRating { get; set; }
}
