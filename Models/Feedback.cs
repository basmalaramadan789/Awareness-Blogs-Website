namespace AwarenessWebsite.Models;

public class Feedback
{
    public int Id { get; set; }
    public string ApplicationUserId { get; set; } = string.Empty;
    public ApplicationUser? ApplicationUser { get; set; }

    public int ContentId { get; set; }
    public Content? Content { get; set; }

    public string Comments { get; set; }= string.Empty;
    public int Rating { get; set; } 
    public DateTime SubmittedAt { get; set; }
}
