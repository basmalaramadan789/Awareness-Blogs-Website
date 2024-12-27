using AwarenessWebsite.Models;
using AwarenessWebsite.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AwarenessWebsite.Controllers;
public class ContentController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ContentController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
    {
        _dbContext = dbContext;
        _webHostEnvironment = webHostEnvironment;
    }

    //public IActionResult CategoryContent(int categoryId)
    //{
    //    // Fetch content for the given categoryId
    //    var content = _dbContext.Contents
    //        .Where(c => c.CategoryId == categoryId)
    //        .ToList();

    //    if (content == null || !content.Any())
    //    {
    //        return NotFound("No content found for this category.");
    //    }

    //    return View(content); // Pass content to the view
    //}

    public IActionResult CategoryContent(int categoryId)
    {
        var content = _dbContext.Contents
            .Include(c => c.Category) // Load the associated Category data
            .Where(c => c.CategoryId == categoryId)
            .ToList();

        if (!content.Any())
        {
            ViewBag.CategoryName = _dbContext.Categories
                .Where(cat => cat.Id == categoryId)
                .Select(cat => cat.Name)
                .FirstOrDefault() ?? "Unknown Category";
        }
        else
        {
            ViewBag.CategoryName = content.First().Category?.Name ?? "Unknown Category";
        }

        return View(content);
    }






    public async Task<IActionResult> Index()
    {
        // Retrieve all content and include the related Category data
        var contents = await _dbContext.Contents
            .Include(c => c.Category)  // Include the related Category
            .ToListAsync();

        return View(contents);
    }


    // GET: Contents/Create
    public IActionResult Create()
    {
        var categories = _dbContext.Categories
         .Select(c => new { c.Id, c.Name })
         .ToList();

        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        return View();
    }

    // POST: Contents/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Content content, IFormFile ImageFile)
    {
        // Populate categories again if ModelState is invalid
        ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name");
        if (ImageFile != null)
        {
            // Ensure the 'images/content' folder exists
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/content");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Save the file in the 'images/content' folder
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
            string uploadPath = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(uploadPath, FileMode.Create))
            {
                ImageFile.CopyTo(fileStream);
            }

            // Store the relative path in the database
            content.ImagePath = "/images/content/" + fileName;
        }
        ModelState.Remove("Category");
        if (ModelState.IsValid)
        {
            _dbContext.Add(content);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Reload categories if model state is invalid
        var categories = _dbContext.Categories
            .Select(c => new { c.Id, c.Name })
            .ToList();

        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        return View(content);
    }





    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var content = await _dbContext.Contents
            .Include(c => c.Category)  // Ensure you include the Category if needed
            .FirstOrDefaultAsync(m => m.Id == id);

        if (content == null)
        {
            return NotFound();
        }

        return View(content);
    }

    // POST: Content/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var content = await _dbContext.Contents.FindAsync(id);
        if (content != null)
        {
            _dbContext.Contents.Remove(content);
            await _dbContext.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }



    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        // Fetch the content by ID, including related entities if necessary
        var content = await _dbContext.Contents
            .Include(c => c.Category) // Include the Category if needed
            .FirstOrDefaultAsync(c => c.Id == id);

        if (content == null)
        {
            return NotFound(); // Return 404 if content is not found
        }

        // Prepare dropdowns and multi-select lists
        ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name", content.CategoryId);
        
        return View(content);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditContent(int id, Content model, IFormFile ImageFile)
    {
        // Fetch the existing content from the database
        var content = await _dbContext.Contents
            .FirstOrDefaultAsync(c => c.Id == id);

        if (content == null)
        {
            return NotFound(); // Return 404 if content is not found
        }

        // Update the content properties
        content.Title = model.Title;
        content.Description = model.Description;
        content.CategoryId = model.CategoryId;
        content.TargetAgeGroup = model.TargetAgeGroup;
        content.Tags = model.Tags;

        // Handle image upload
        if (ImageFile != null && ImageFile.Length > 0)
        {
            // Define the upload path
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "content");

            // Create the directory if it doesn't exist
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Generate a unique file name
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
            string filePath = Path.Combine(uploadPath, fileName);

            // Save the file to the server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(fileStream);
            }

            // Update the ImagePath property
            content.ImagePath = Path.Combine("images", "contents", fileName).Replace("\\", "/");
        }

        // Save changes to the database
        _dbContext.Contents.Update(content);
        await _dbContext.SaveChangesAsync();

        // Redirect to a relevant action (e.g., Index or Details)
        return RedirectToAction(nameof(Index));
    }
}
