using App.Enum;

namespace App.Data;

public class WorkoutMuscle : BaseEntity
{ 
    public Workout Workout { get; set; }

    public Muscle Muscle { get; set; }
}