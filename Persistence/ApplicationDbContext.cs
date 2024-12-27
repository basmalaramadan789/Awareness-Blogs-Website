using AwarenessWebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AwarenessWebsite.Persistence;

public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        
        modelBuilder.Entity<Recommendation>()
            .HasOne(r => r.ApplicationUser)
            .WithMany(u => u.Recommendations)
            .HasForeignKey(r => r.ApplicationUserId);

        modelBuilder.Entity<Recommendation>()
            .HasOne(r => r.Content)
            .WithMany(c => c.Recommendations)
            .HasForeignKey(r => r.ContentId);

        
        modelBuilder.Entity<Feedback>()
            .HasOne(f => f.ApplicationUser)
            .WithMany()
            .HasForeignKey(f => f.ApplicationUserId);

        modelBuilder.Entity<Feedback>()
            .HasOne(f => f.Content)
            .WithMany()
            .HasForeignKey(f => f.ContentId);


        modelBuilder.Entity<Content>()
        .HasOne(c => c.Category)      
        .WithMany(c => c.Contents)    
        .HasForeignKey(c => c.CategoryId);


        modelBuilder.Entity<Bookmark>()
            .HasOne(b => b.ApplicationUser)
            .WithMany()
            .HasForeignKey(b => b.ApplicationUserId);

        modelBuilder.Entity<Bookmark>()
            .HasOne(b => b.Content)
            .WithMany()
            .HasForeignKey(b => b.ContentId);

        modelBuilder.Entity<Category>().HasData(
    new Category
    {
        Id = 1,
        Name = "Self-Awareness",
        Description = "Enhance your understanding of yourself and your goals. Learn about personal growth and self-reflection.",
        ImagePath = "/images/s-2.png"
    },
    new Category
    {
        Id = 2,
        Name = "Skill Development",
        Description = "Acquire new skills and build your expertise in various fields, from technical to creative.",
        ImagePath = "/images/s-1.png"
    },
    new Category
    {
        Id = 3,
        Name = "Community Engagement",
        Description = "Connect with others through meaningful discussions and activities that foster community growth.",
        ImagePath = "/images/s-3.png"
    },
    new Category
    {
        Id = 4,
        Name = "Educational Growth",
        Description = "Explore educational content tailored to your interests and specializations to enhance learning.",
        ImagePath = "/images/s-4.png"
    }
);

    }

}