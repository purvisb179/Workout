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
    [Enum.DisplayName("Trapezius")]
    [MuscleGroup(MuscleGroup.Back)]
    Trapezius,
    [Enum.DisplayName("Latissimus")]
    [MuscleGroup(MuscleGroup.Back)]
    LatissimusDorsi,
    [Enum.DisplayName("Biceps")]
    [MuscleGroup(MuscleGroup.Arms)]
    Biceps,
    [Enum.DisplayName("Triceps")]
    [MuscleGroup(MuscleGroup.Arms)]
    Triceps,
    [Enum.DisplayName("Forearm")]
    [MuscleGroup(MuscleGroup.Arms)]
    Forearm,
    [Enum.DisplayName("Deltoid")]
    [MuscleGroup(MuscleGroup.Shoulders)]
    Deltoid,
    [Enum.DisplayName("Glutes")]
    [MuscleGroup(MuscleGroup.Legs)]
    Glutes,
    [Enum.DisplayName("Quadriceps")]
    [MuscleGroup(MuscleGroup.Legs)]
    Quadriceps,
    [Enum.DisplayName("Hamstrings")]
    [MuscleGroup(MuscleGroup.Legs)]
    Hamstrings,
    [Enum.DisplayName("Adductor")]
    [MuscleGroup(MuscleGroup.Legs)]
    Adductor,
    [Enum.DisplayName("Obliques")]
    [MuscleGroup(MuscleGroup.Core)]
    Obliques,
    [Enum.DisplayName("Abdominals")]
    [MuscleGroup(MuscleGroup.Core)]
    Abdominals,
}