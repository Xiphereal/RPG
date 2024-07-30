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
            Character.Warrior
                .Abilities
                .Should().ContainEquivalentOf(Ability.Slam());
        }

        [Test]
        public void WarriorLearnsChargeAtLevel2()
        {
            Character warrior = Character.Warrior;
            warrior.LevelUp();

            warrior
                .Abilities
                .Should().ContainEquivalentOf(Ability.Charge());
        }

        [Test]
        public void WarriorLearnsBattleShoutAtLevel10()
        {
            Character warrior = Character.Warrior;
            warrior.LevelUpTo(10);

            warrior
                .Abilities
                .Should().ContainEquivalentOf(Ability.BattleShout());
        }

        [Test]
        public void AbilitiesAreNotAvailable_WhenNotEnoughResources()
        {
            var caster = Character.Warrior;

            caster.HasAvailable(nameof(Ability.Slam)).Should().BeFalse();
        }

        [Test]
        public void AbilitiesAreAvailable_WhenEnoughResources()
        {
            var caster = Character.Warrior;
            caster.GenerateRage(Ability.Slam().ResourceConsumption);

            caster.HasAvailable(nameof(Ability.Slam)).Should().BeTrue();
        }

        [Test]
        public void AbilitiesAreNotAvailable_WhenInCooldown()
        {
            var caster = WarriorWithAbilityWithCD();

            Ability ability = caster.Abilities.First(x => x.CooldownInMillis > 0);
            ability
                .Use(by: caster, on: Target.Invencible());

            caster.HasAvailable(ability.Name).Should().BeFalse();
        }

        private static Warrior WarriorWithAbilityWithCD()
        {
            Warrior warrior = Character.Warrior;
            warrior.LevelUp();

            return warrior;
        }

        [Test]
        public void AbilitiesCanBeQueried()
        {
            var warrior = Character.Warrior;

            warrior.Ability("Slam").Name.Should().Be("Slam");
        }

        [Test]
        public void TimeInfluenceIsPropagatedFromTheCharacter_DownToItsAbilities()
        {
            // Arrange.
            Character warriorWithCharge = Character.Warrior;
            warriorWithCharge.LevelUp();

            Ability charge = warriorWithCharge
                .Abilities
                .First(x => x.Name == nameof(Ability.Charge));
            charge.Use(by: warriorWithCharge, on: Target.Invencible());

            // Act.
            const int elapsedTime = 1000;
            warriorWithCharge.PassTime(elapsedTime);

            // Assert.
            charge.RemainingCooldownInMillis.Should().Be(charge.CooldownInMillis - elapsedTime);
        }
    }

}
