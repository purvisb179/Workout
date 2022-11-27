using App.Data.Models;
using App.Enum;

namespace App.Models;

public class WorkoutModel : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public List<Muscle> WorkoutMuscle { get; set; }
}