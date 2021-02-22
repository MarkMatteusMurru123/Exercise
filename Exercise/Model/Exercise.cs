using System.Text.Json.Serialization;

namespace Exercise.Model
{
    public record Exercise
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public ExerciseIntensity Intensity { get; init; }
        public int RecommendedDurationInSeconds { get; init; }
        public int RecommendedRestTimeInSecondsBeforeExercise { get; init; }
        public int RecommendedRestTimeInSecondsAfterExercise { get; init; }
        public string? RestTimeInstructions { get; init; }

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExerciseIntensity
    {
        Low = 1,
        Normal = 2,
        High = 3
    }
}
