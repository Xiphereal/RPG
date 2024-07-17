using FluentAssertions;
using Models.Characters;
using Models.Skills;

namespace Models.Tests
{
    public class CharacterTests
    {
        [Test]
        public void StartWithDefaultStats()
        {
            Character.Warrior.Health.Should().Be(500);
            Character.Warrior.AttackPower.Should().Be(20);
        }

        [Test]
        public void WarriorStartsWithSlam()
        {
            var time = new Time();

            Character.Warrior
                .Abilities
                .Should().ContainEquivalentOf(Skill.Slam(time));
        }
    }
}
