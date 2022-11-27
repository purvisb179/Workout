using App.Enum;
using App.Models;

namespace App.Data.Models;

public class WorkoutMuscleModel : BaseModel
{
    public WorkoutModel Workout { get; set; }

    public Muscle Muscle { get; set; }
}