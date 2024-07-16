using FluentAssertions;

namespace Models.Tests
{
    public class CharacterTests
    {
        [Test]
        public void StartWithDefaultStats()
        {
            Character.Warrior.Health.Should().Be(500);
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
