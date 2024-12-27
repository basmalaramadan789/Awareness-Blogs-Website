using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AwarenessWebsite.Migrations
{
    /// <inheritdoc />
    public partial class seedcategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, "Enhance your understanding of yourself and your goals. Learn about personal growth and self-reflection.", "/images/categories/self-awareness.jpg", "Self-Awareness" },
                    { 2, "Acquire new skills and build your expertise in various fields, from technical to creative.", "/images/categories/skill-development.jpg", "Skill Development" },
                    { 3, "Connect with others through meaningful discussions and activities that foster community growth.", "/images/categories/community-engagement.jpg", "Community Engagement" },
                    { 4, "Explore educational content tailored to your interests and specializations to enhance learning.", "/images/categories/educational-growth.jpg", "Educational Growth" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
