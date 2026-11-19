using FlashJobs.Models;
using Microsoft.EntityFrameworkCore;


namespace FlashJobs.Context;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<JobPosts> JobPosts { get; set; }
    public DbSet<JobSkills> JobSkills { get; set; }
    public DbSet<Skills> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobSkills>()
            .HasIndex(jobSkill => new { jobSkill.JobPostId, jobSkill.SkillId })
            .IsUnique();

        modelBuilder.Entity<JobSkills>()
            .HasOne(jobSkill => jobSkill.JobPost)
            .WithMany(jobPost => jobPost.JobSkills)
            .HasForeignKey(jobSkill => jobSkill.JobPostId);

        modelBuilder.Entity<JobSkills>()
            .HasOne(jobSkill => jobSkill.Skill)
            .WithMany(skill => skill.JobSkills)
            .HasForeignKey(jobSkill => jobSkill.SkillId);
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<ITimeStampedEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
                entry.Entity.UpdatedAt = now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = now;
                entry.Property(entity => entity.CreatedAt).IsModified = false;
            }
        }
    }
}