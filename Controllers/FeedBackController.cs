using AwarenessWebsite.Models;
using AwarenessWebsite.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AwarenessWebsite.Controllers;
public class FeedBackController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public FeedBackController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    //// Display content with feedback form
    //public async Task<IActionResult> Details(int id)
    //{
    //    var content = await _context.Contents
    //        .Include(c => c.Category)
    //        .FirstOrDefaultAsync(c => c.Id == id);

    //    if (content == null)
    //    {
    //        return NotFound();
    //    }

    //    ViewBag.ContentId = content.Id;
    //    ViewBag.CategoryName = content.Category?.Name;

    //    return View(content);
    //}

    //// Handle feedback submission
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> AddFeedback(int contentId, string comments, int rating)
    //{
    //    var userId = _userManager.GetUserId(User);
    //    var content = await _context.Contents.FindAsync(contentId);

    //    if (content == null)
    //    {
    //        return NotFound();
    //    }

    //    var feedback = new Feedback
    //    {
    //        ApplicationUserId = userId,
    //        ContentId = contentId,
    //        Comments = comments,
    //        Rating = rating,
    //        SubmittedAt = DateTime.Now
    //    };

    //    _context.Feedbacks.Add(feedback);
    //    await _context.SaveChangesAsync();

    //    return RedirectToAction("Details", new { id = contentId });
    //}


    public IActionResult GiveFeedback(int contentId)
    {
        var content = _context.Contents.FirstOrDefault(c => c.Id == contentId);
        if (content == null)
        {
            return NotFound();
        }

        ViewBag.ContentId = contentId;
        return View();
    }

    // Handle feedback submission
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SubmitFeedback(int contentId, string comments, int rating)
    {
        var userId = _userManager.GetUserId(User);
        var content = await _context.Contents.FindAsync(contentId);

        if (content == null)
        {
            return NotFound();
        }
        var feedback = new Feedback
        {
            ApplicationUserId = userId,
            ContentId = contentId,
            Comments = comments,
            Rating = rating,
            SubmittedAt = DateTime.Now
        };

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home"); // Or redirect to the content detail page
    }
}
