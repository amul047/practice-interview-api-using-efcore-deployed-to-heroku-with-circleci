using Microsoft.EntityFrameworkCore;
using PrepPeered.Api.Entities;

namespace PrepPeered.Api.Data
{
    public class PrepPeeredDbContext : DbContext
    {
        public PrepPeeredDbContext(DbContextOptions<PrepPeeredDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Dashboard> Dashboards { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        public DbSet<Industry> Industries { get; set; }

        public DbSet<Interview> Interviews { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Tip> Tips { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<SeniorityLevel> SeniorityLevels { get; set; }

        public DbSet<SetupCheck> SetupChecks { get; set; }
    }
}