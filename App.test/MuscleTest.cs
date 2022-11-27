using System.Linq;
using App.Enum;
using NUnit.Framework;

namespace App.test;

public class MuscleTest
{
    [Test]
    public void MuscleEnumTest()
    {
        const Muscle muscle = Muscle.PectoralisMajor;
        Assert.AreEqual("Pectoralis Major", muscle.GetDisplayName());
        Assert.AreEqual(MuscleGroup.Chest, muscle.GetMuscleGroup());
    }
    
    [Test]
    public void MuscleEnumListTest()
    {
        var muscleList = EnumExtensions.GetEnumerable<Muscle>();
        Assert.IsTrue(muscleList.Count() > 1);
    }
}