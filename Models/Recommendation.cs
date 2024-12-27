namespace AwarenessWebsite.Models;

public class Recommendation
{
    public int Id { get; set; }
    public string ApplicationUserId { get; set; } = string.Empty;
    public ApplicationUser? ApplicationUser { get; set; }

    public int ContentId { get; set; }
    public Content? Content { get; set; }

    public DateTime RecommendedAt { get; set; }
}
