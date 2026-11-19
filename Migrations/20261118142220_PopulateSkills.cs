using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace FlashJobs.Migrations
{
    /// <inheritdoc />
    public partial class PopulateSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name" },
                values: new object[,]
                {
                { "C#" },
                { "JavaScript" },
                { "Python" },
                { "TypeScript" },
                { "Go" },
                { "Rust" },
                { "Kotlin" },
                { "Swift" },
                { "PHP" },
                { "Ruby" },
                { "Dart" },
                { "Java" },
                { "SQL" },
                { "HTML" },
                { "CSS" },
                { "NoSQL" },
                { "GraphQL" },
                { "REST" },
                {"Docker"},
                { "Kubernetes" },
                { "AWS" },
                { "Azure" },
                { "GCP" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValues: new object[]
                {
                    "TypeScript",
                    "Go",
                    "Rust",
                    "Kotlin",
                    "Swift",
                    "PHP",
                    "Ruby",
                    "Dart",
                    "HTML",
                    "CSS",
                    "NoSQL",
                    "GraphQL",
                    "REST",
                    "Docker",
                    "Kubernetes",
                    "AWS",
                    "Azure",
                    "GCP"
                }
            );
        }
    }
}
