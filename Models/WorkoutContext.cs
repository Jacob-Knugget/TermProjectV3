using Microsoft.EntityFrameworkCore;

namespace TermProject.Models
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options) { }
        public DbSet<Workouts> Plan { get; set; } = default!;
        public DbSet<BodyGroup> BodyGroup { get; set; } = default!;
        ICollection<BodyGroup> BodyGroups { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyGroup>().HasData(
                new BodyGroup
                {
                    BodyGroupId = 1,
                    BodyGroupName = "Chest",
                },
                new BodyGroup
                {
                    BodyGroupId = 2,
                    BodyGroupName = "Back",
                },
                new BodyGroup
                {
                    BodyGroupId = 3,
                    BodyGroupName = "Arms",
                },
                new BodyGroup
                {
                    BodyGroupId = 4,
                    BodyGroupName = "Legs",
                }
            );
            modelBuilder.Entity<Workouts>().HasData(
                new Workouts
                {
                    ID = 1,
                    BodyGroupId = 1,
                    Name = "Barbell Bench Press",
                    Sets = 4,
                    Reps = 12,
                    Weight = 200
                },
                new Workouts
                {
                    ID = 2,
                    BodyGroupId = 1,
                    Name = "Dumbbell Fly",
                    Sets = 4,
                    Reps = 12,
                    Weight = 40
                },
                new Workouts
                {
                    ID = 3,
                    BodyGroupId = 3,
                    Name = "Skullcrusher",
                    Sets = 4,
                    Reps = 12,
                    Weight = 30
                }
            );
        }
    }
}
