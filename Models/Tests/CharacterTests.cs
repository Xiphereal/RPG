using FluentAssertions;
using Models.Abilities;
using Models.Characters;

namespace Models.Tests
{
    public class CharacterTests
    {
        [Test]
        public void StartWithDefaultStats()
        {
            Character.Warrior.Health.Should().Be(500);
            Character.Warrior.AttackPower.Should().Be(20);
            Character.Warrior.Level.Should().Be(1);
        }

        [Test]
        public void WarriorStartsWithSlam()
        {
            var time = new Time();

            Character.Warrior
                .Abilities
                .Should().ContainEquivalentOf(Ability.Slam(time));
        }

        [Test]
        public void WarriorLearnsChargeAtLevel2()
        {
            var time = new Time();
            Character warrior = Character.Warrior;
            warrior.LevelUp();

            warrior
                .Abilities
                .Should().ContainEquivalentOf(Ability.Charge(time));
        }
    }
}
