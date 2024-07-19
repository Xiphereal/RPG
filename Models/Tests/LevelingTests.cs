using FluentAssertions;
using Models.Characters;

namespace Models.Tests
{
    public class LevelingTests
    {
        [Test]
        public void CanLevelUp()
        {
            Character character = Character.Warrior;

            character.LevelUp();

            character.Level.Should().Be(2);
        }

        [Test]
        public void LevelUpByExperience()
        {
            Character character = Character.Warrior;

            character.GainExp(100);

            character.Level.Should().Be(2);
        }

        [Test]
        public void DoesNotLevelUp_IfNotEnoughtExperience()
        {
            Character character = Character.Warrior;

            character.GainExp(50);

            character.Level.Should().Be(1);
        }

        [Test]
        public void ExperienceIsAcumulative()
        {
            Character character = Character.Warrior;

            character.GainExp(50);
            character.Level.Should().Be(1);

            character.GainExp(50);
            character.Level.Should().Be(2);
        }

        [Test]
        public void ExperienceIsResetAfterLevelUp()
        {
            Character character = Character.Warrior;

            character.GainExp(100);
            character.Level.Should().Be(2);

            character.Experience.Should().Be(0);
        }

        [Test]
        public void ExperienceRequiredForLevelUp_IsIncreasedForEachLevel()
        {
            Character character = Character.Warrior;

            int previousRequirement = character.ExperienceRequiredForLevelUp;
            character.LevelUp();

            character.ExperienceRequiredForLevelUp
                .Should().BeGreaterThan(previousRequirement);
        }
    }
}
