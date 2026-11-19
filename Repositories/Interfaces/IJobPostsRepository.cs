using FlashJobs.Models;

namespace FlashJobs.Repositories.Interfaces
{
    public interface IJobPostsRepository
    {
        Task<IEnumerable<JobPosts>> GetAllAsync();
        Task<JobPosts?> GetByIdAsync(int id);

    }

}