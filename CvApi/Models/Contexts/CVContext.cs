using CvApi.Models.Entities;
using CvApi.Models.Entities.ResolvingTables;
using Microsoft.EntityFrameworkCore;

namespace CvApi.Models.Contexts
{
    public class CVContext : DbContext
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options)
        {
        }

        public DbSet<User> UserEntities { get; set; }
        public DbSet<Company> CompanyEntities { get; set; }
        public DbSet<Experience> ExperienceEntities { get; set; }
        public DbSet<JobAdvertisement> JobAdvertisementEntities { get; set; }
        public DbSet<Skill> SkillEntities { get; set; }
        public DbSet<Application> ApplicationEntities { get; set; }
        public DbSet<JobSkill> JobSkillEntities { get; set; }
        public DbSet<UserSkill> UserSkillEntities { get; set; }
    }
}
