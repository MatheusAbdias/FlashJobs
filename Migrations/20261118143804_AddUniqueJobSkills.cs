using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashJobs.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueJobSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobSkills_JobPostId",
                table: "JobSkills");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobPostId_SkillId",
                table: "JobSkills",
                columns: new[] { "JobPostId", "SkillId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobSkills_JobPostId_SkillId",
                table: "JobSkills");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobPostId",
                table: "JobSkills",
                column: "JobPostId");
        }
    }
}
