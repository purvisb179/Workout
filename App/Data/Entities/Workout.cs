using App.Enum;

namespace App.Data;

public class Workout : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public List<WorkoutMuscle> WorkoutMuscle { get; set; }
}