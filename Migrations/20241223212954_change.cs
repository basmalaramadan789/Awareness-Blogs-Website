using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwarenessWebsite.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_AspNetUsers_ApplicationUserId",
                table: "Bookmark");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Content_ContentId",
                table: "Bookmark");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_ApplicationUserId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Content_ContentId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendation_AspNetUsers_ApplicationUserId",
                table: "Recommendation");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendation_Content_ContentId",
                table: "Recommendation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendation",
                table: "Recommendation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Content");

            migrationBuilder.RenameTable(
                name: "Recommendation",
                newName: "Recommendations");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "Contents");

            migrationBuilder.RenameTable(
                name: "Bookmark",
                newName: "Bookmarks");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendation_ContentId",
                table: "Recommendations",
                newName: "IX_Recommendations_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendation_ApplicationUserId",
                table: "Recommendations",
                newName: "IX_Recommendations_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_ContentId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_ApplicationUserId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmark_ContentId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmark_ApplicationUserId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "ContentId1",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Bookmarks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContentId1",
                table: "Bookmarks",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contents",
                table: "Contents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ContentId1",
                table: "Feedbacks",
                column: "ContentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CategoryId",
                table: "Contents",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_ApplicationUserId1",
                table: "Bookmarks",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_ContentId1",
                table: "Bookmarks",
                column: "ContentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_AspNetUsers_ApplicationUserId",
                table: "Bookmarks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_AspNetUsers_ApplicationUserId1",
                table: "Bookmarks",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Contents_ContentId",
                table: "Bookmarks",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Contents_ContentId1",
                table: "Bookmarks",
                column: "ContentId1",
                principalTable: "Contents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Categories_CategoryId",
                table: "Contents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ApplicationUserId",
                table: "Feedbacks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Contents_ContentId",
                table: "Feedbacks",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Contents_ContentId1",
                table: "Feedbacks",
                column: "ContentId1",
                principalTable: "Contents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_AspNetUsers_ApplicationUserId",
                table: "Recommendations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Contents_ContentId",
                table: "Recommendations",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_AspNetUsers_ApplicationUserId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_AspNetUsers_ApplicationUserId1",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Contents_ContentId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Contents_ContentId1",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Categories_CategoryId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ApplicationUserId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Contents_ContentId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Contents_ContentId1",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_AspNetUsers_ApplicationUserId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Contents_ContentId",
                table: "Recommendations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ContentId1",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contents",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_CategoryId",
                table: "Contents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_ApplicationUserId1",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_ContentId1",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "ContentId1",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "ContentId1",
                table: "Bookmarks");

            migrationBuilder.RenameTable(
                name: "Recommendations",
                newName: "Recommendation");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "Feedback");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "Content");

            migrationBuilder.RenameTable(
                name: "Bookmarks",
                newName: "Bookmark");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_ContentId",
                table: "Recommendation",
                newName: "IX_Recommendation_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_ApplicationUserId",
                table: "Recommendation",
                newName: "IX_Recommendation_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_ContentId",
                table: "Feedback",
                newName: "IX_Feedback_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_ApplicationUserId",
                table: "Feedback",
                newName: "IX_Feedback_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_ContentId",
                table: "Bookmark",
                newName: "IX_Bookmark_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_ApplicationUserId",
                table: "Bookmark",
                newName: "IX_Bookmark_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendation",
                table: "Recommendation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_AspNetUsers_ApplicationUserId",
                table: "Bookmark",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Content_ContentId",
                table: "Bookmark",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_AspNetUsers_ApplicationUserId",
                table: "Feedback",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Content_ContentId",
                table: "Feedback",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendation_AspNetUsers_ApplicationUserId",
                table: "Recommendation",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendation_Content_ContentId",
                table: "Recommendation",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
