using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Enum;
using NUnit.Framework;

namespace App.test;

public class MuscleTest
{
    [Test]
    public async Task MuscleEnumTest()
    {
        const Muscle muscle = Muscle.PectoralisMajor;
        Assert.AreEqual("Pectoralis Major", muscle.GetDisplayName());
        Assert.AreEqual(MuscleGroup.Chest, muscle.GetMuscleGroup());
    }
    
    [Test]
    public async Task MuscleEnumListTest()
    {
        var muscleList = EnumExtensions.GetEnumerable<Muscle>();
        Assert.IsTrue(muscleList.Count() > 1);
    }
}