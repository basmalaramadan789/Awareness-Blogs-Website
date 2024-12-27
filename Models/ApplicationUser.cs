using Microsoft.AspNetCore.Identity;

namespace AwarenessWebsite.Models;

public class ApplicationUser:IdentityUser
{
    public string FullName { get; set; }=string.Empty;
    public int Age { get; set; }
    public string Specialization { get; set; } = string.Empty;
    public string Hobbies { get; set; } = string.Empty;
    public string ProfilePicturePath { get; set; }  =string.Empty;

    
    public ICollection<Recommendation> Recommendations { get; set; }
    public ICollection<Bookmark> Bookmarks { get; set; }
   
}
