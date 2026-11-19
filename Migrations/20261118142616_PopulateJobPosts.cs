using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashJobs.Migrations
{
    /// <inheritdoc />
    public partial class PopulateJobPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Title", "Description", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { "Desenvolvedor Backend .NET", "Desenvolvimento e manutenção de APIs e serviços com ASP.NET Core.", new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc) },
                    { "Desenvolvedor Frontend", "Construção de interfaces modernas e acessíveis com TypeScript.", new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc) },
                    { "Engenheiro de Dados", "Implementação de pipelines, consultas SQL e processamento de dados.", new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc) },
                    { "Engenheiro de Cloud", "Gestão de infraestrutura e aplicações na nuvem com Docker e AWS.", new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc) },
                    { "Desenvolvedor Full Stack", "Desenvolvimento completo de aplicações web com C# e JavaScript.", new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 18, 13, 0, 0, DateTimeKind.Utc) }
                }
            );

            migrationBuilder.Sql("""
                INSERT INTO JobSkills (JobPostId, SkillId)
                SELECT job.Id, skill.Id
                FROM JobPosts AS job
                JOIN Skills AS skill
                    ON (job.Title = N'Desenvolvedor Backend .NET' AND skill.Name IN (N'C#', N'SQL', N'ReST', N'Azure'))
                    OR (job.Title = N'Desenvolvedor Frontend' AND skill.Name IN (N'JavaScript', N'TypeScript', N'HTML', N'CSS'))
                    OR (job.Title = N'Engenheiro de Dados' AND skill.Name IN (N'Python', N'SQL', N'NoSQL'))
                    OR (job.Title = N'Engenheiro de Cloud' AND skill.Name IN (N'Docker', N'Kubernetes', N'AWS', N'Azure'))
                    OR (job.Title = N'Desenvolvedor Full Stack' AND skill.Name IN (N'C#', N'JavaScript', N'SQL', N'GraphQL'));
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobPosts",
                keyColumn: "Title",
                keyValues: new object[]
                {
                    "Desenvolvedor Backend .NET",
                    "Desenvolvedor Frontend",
                    "Engenheiro de Dados",
                    "Engenheiro de Cloud",
                    "Desenvolvedor Full Stack"
                }
            );
        }
    }
}
