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

   

    public IActionResult CategoryContent(int categoryId)
    {
        var content = _dbContext.Contents
            .Include(c => c.Category) 
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


    
    public IActionResult Create()
    {
        var categories = _dbContext.Categories
         .Select(c => new { c.Id, c.Name })
         .ToList();

        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Content content, IFormFile ImageFile)
    {
       
        ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name");
        if (ImageFile != null)
        {
            
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/content");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
            string uploadPath = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(uploadPath, FileMode.Create))
            {
                ImageFile.CopyTo(fileStream);
            }

           
            content.ImagePath = "/images/content/" + fileName;
        }
        ModelState.Remove("Category");
        if (ModelState.IsValid)
        {
            _dbContext.Add(content);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
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
            .Include(c => c.Category)  
            .FirstOrDefaultAsync(m => m.Id == id);

        if (content == null)
        {
            return NotFound();
        }

        return View(content);
    }

  
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
        
        var content = await _dbContext.Contents
            .Include(c => c.Category) 
            .FirstOrDefaultAsync(c => c.Id == id);

        if (content == null)
        {
            return NotFound(); 
        }

        
        ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name", content.CategoryId);
        
        return View(content);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditContent(int id, Content model, IFormFile ImageFile)
    {
        
        var content = await _dbContext.Contents
            .FirstOrDefaultAsync(c => c.Id == id);

        if (content == null)
        {
            return NotFound(); 
        }

       
        content.Title = model.Title;
        content.Description = model.Description;
        content.CategoryId = model.CategoryId;
        content.TargetAgeGroup = model.TargetAgeGroup;
        content.Tags = model.Tags;

    
        if (ImageFile != null && ImageFile.Length > 0)
        {
            
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "content");

            
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

           
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
            string filePath = Path.Combine(uploadPath, fileName);

            
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(fileStream);
            }

            
            content.ImagePath = Path.Combine("images", "contents", fileName).Replace("\\", "/");
        }

        
        _dbContext.Contents.Update(content);
        await _dbContext.SaveChangesAsync();

        
        return RedirectToAction(nameof(Index));
    }
}
