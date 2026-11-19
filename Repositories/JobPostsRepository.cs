using FlashJobs.Repositories.Interfaces;
using FlashJobs.Context;
using FlashJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashJobs.Repositories
{
    public class JobPostsRepository : IJobPostsRepository
    {
        private readonly AppDBContext _context;

        public JobPostsRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobPosts>> GetAllAsync()
        {
            return await _context.Set<JobPosts>()
                .AsNoTracking()
                .Include(job => job.JobSkills)
                    .ThenInclude(jobSkill => jobSkill.Skill)
                .ToListAsync();
        }

        public async Task<JobPosts?> GetByIdAsync(int id)
        {
            return await _context.Set<JobPosts>().AsNoTracking()
                .Include(job => job.JobSkills)
                    .ThenInclude(jobSkill => jobSkill.Skill)
                .FirstOrDefaultAsync(job => job.Id == id);
        }
    }
}