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
