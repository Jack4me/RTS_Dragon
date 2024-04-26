using System.Collections.Generic;
using Configuration;
using NUnit.Framework;
using Unit;

namespace Tests {
    public class UnitDataTest : BaseTest {
        private static List<string> units = new List<string>()
        {
            "BasicWarrior",
            "BasicMage"
        };

        [Test]
        public void TestWithUnits([ValueSource("units")] string unit) {
            UnitData data = LoadUnit(unit);
            Assert.IsNotNull(data, $"UnitData {unit} not found.");
            Assert.IsTrue(data.Health > 0);
            Assert.IsTrue(data.Attack > 0);
            Assert.IsTrue(data.Defense >= 0);
            Assert.IsTrue(data.WalkSpeed > 0);
            Assert.IsNotNull(data.SelectedColor);
            Assert.IsFalse(data.AnimationStateAttack01 == "");
            Assert.IsFalse(data.AnimationStateAttack02 == "");
            Assert.IsFalse(data.AnimationStateDefense == "");
            Assert.IsFalse(data.AnimationStateMove == "");
            Assert.IsFalse(data.AnimationStateIdle == "");
            Assert.IsFalse(data.AnimationStateCollect == "");
            Assert.IsFalse(data.AnimationStateDeath == "");
            Assert.IsTrue(data.AttackRange >= 0);
            Assert.IsTrue(data.ColliderSize > 0);
            Assert.IsTrue(data.Level >= 0);
            Assert.IsTrue(data.LevelMultiplier > 0);
            Assert.IsFalse(data.Actions == ActionType.None);
        }
    }
}