using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Exercise> ExerciseList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = 1,
                    Title = "Kätekõverdused jala tõstega",
                    Description = "Tavalised kätekõverdused korda mööda jalga tõstes",
                    Intensity = ExerciseIntensity.Normal,
                    RecommendedDurationInSeconds = 40,
                    RecommendedRestTimeInSecondsBeforeExercise = 10,
                    RecommendedRestTimeInSecondsAfterExercise = 10
                },
                new Exercise
                {
                    Id = 2,
                    Title = "Slaalomhüpped",
                    Description = "Kükist hüpped küljelt küljele",
                    Intensity = ExerciseIntensity.High,
                    RecommendedDurationInSeconds = 20,
                    RecommendedRestTimeInSecondsBeforeExercise = 10,
                    RecommendedRestTimeInSecondsAfterExercise = 10,
                    RestTimeInstructions = "Venita reie esikülge"
                },
                new Exercise
                {
                    Id = 3,
                    Title = "Alt läbi jooks",
                    Description = "Toenglamangus jooksmine",
                    Intensity = ExerciseIntensity.Normal,
                    RecommendedDurationInSeconds = 30,
                    RecommendedRestTimeInSecondsBeforeExercise = 10,
                    RecommendedRestTimeInSecondsAfterExercise = 10,
                }
            );
        }
    }
    
}

