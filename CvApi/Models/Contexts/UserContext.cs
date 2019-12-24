using Microsoft.EntityFrameworkCore;
using CvApi.Models.Entities;

namespace CvApi.Models.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> UserEntities { get; set; }
    }
}
