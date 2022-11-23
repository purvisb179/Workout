using System.ComponentModel;

namespace App.Enum;

public enum Muscle
{
    [Enum.DisplayName("Pectoralis Major")]
    [MuscleGroup(MuscleGroup.Chest)]
    PectoralisMajor,
    [Enum.DisplayName("Pectoralis Minor")]
    [MuscleGroup(MuscleGroup.Chest)]
    PectoralisMinor,
}