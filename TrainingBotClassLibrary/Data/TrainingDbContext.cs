using Microsoft.EntityFrameworkCore;
namespace TrainingBotClassLibrary
{
    public class TrainingDbContext :DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options)
        {

        }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutSet> WorkoutSets { get; set; }

    }
}