using FlashJobs.Context;
using FlashJobs.Repositories;
using FlashJobs.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlashJobs.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'DefaultConnection' is not configured.");
        }

        services.AddDbContext<AppDBContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IJobPostsRepository, JobPostsRepository>();

        return services;
    }
}
