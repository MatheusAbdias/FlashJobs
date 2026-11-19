using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashJobs.Models;

[Table("JobPosts")]
public class JobPosts : ITimeStampedEntity
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "O título da vaga é obrigatório.")]
    [MinLength(10, ErrorMessage = "O título da vaga deve ter no mínimo 10 caracteres.")]
    [MaxLength(500, ErrorMessage = "O título da vaga deve ter no máximo 500 caracteres.")]
    [Display(Name = "Nome da vaga")]
    required public string Title { get; set; }

    [Required(ErrorMessage = "A descrição da vaga é obrigatória.")]
    [MinLength(10, ErrorMessage = "A descrição da vaga deve ter no mínimo 10 caracteres.")]
    [MaxLength(500, ErrorMessage = "A descrição da vaga deve ter no máximo 500 caracteres.")]
    [Display(Name = "Descrição da vaga")]
    required public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<JobSkills> JobSkills { get; set; } = [];
}

[Table("JobSkills")]
public class JobSkills
{
    [Key]
    public int Id { get; set; }

    public JobPosts JobPost { get; set; } = null!;
    public int JobPostId { get; set; }

    public Skills Skill { get; set; } = null!;
    public int SkillId { get; set; }
}

[Table("Skills")]
public class Skills
{
    [Key]
    public int Id { get; set; }

    [Required]
    required public string Name { get; set; }

    public ICollection<JobSkills> JobSkills { get; set; } = [];
}

