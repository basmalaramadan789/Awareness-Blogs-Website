namespace AwarenessWebsite.Models;

public class Bookmark
{
    public int Id { get; set; }
    public string ApplicationUserId { get; set; } = string.Empty;
    public ApplicationUser? ApplicationUser { get; set; }

    public int ContentId { get; set; }
    public Content? Content { get; set; }

    public DateTime BookmarkedAt { get; set; }
}
