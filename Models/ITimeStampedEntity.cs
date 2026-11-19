namespace FlashJobs.Models;

public interface ITimeStampedEntity
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}
