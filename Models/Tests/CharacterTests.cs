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

        [Test]
        public void AbilitiesAreNotAvailable_WhenNotEnoughResources()
        {
            var time = new Time();
            var caster = Character.Warrior;

            caster.HasAvailable(nameof(Ability.Slam)).Should().BeFalse();
        }

        [Test]
        public void AbilitiesAreAvailable_WhenEnoughResources()
        {
            var time = new Time();
            var caster = Character.Warrior;
            caster.GenerateRage(Ability.Slam(time).ResourceConsumption);

            caster.HasAvailable(nameof(Ability.Slam)).Should().BeTrue();
        }

        [Test]
        public void AbilitiesAreNotAvailable_WhenInCooldown()
        {
            var time = new Time();
            var caster = WarriorWithAbilityWithCD();

            Ability ability = caster.Abilities.First(x => x.CooldownInMillis > 0);
            ability
                .Use(by: caster, on: new Target(9999));

            caster.HasAvailable(ability.Name).Should().BeFalse();
        }

        private static Warrior WarriorWithAbilityWithCD()
        {
            Warrior warrior = Character.Warrior;
            warrior.LevelUp();

            return warrior;
        }

        [Test]
        public void TimeInfluenceIsPropagatedFromTheCharacter_DownToItsAbilities()
        {
            // Arrange.
            var time = new Time();

            Character warriorWithCharge = Character.Warrior;
            warriorWithCharge.LevelUp();

            // Act.
            warriorWithCharge.AffectedBy(time);

            // Assert.
            Ability charge = warriorWithCharge
                .Abilities
                .First(x => x.Name == nameof(Ability.Charge));
            charge.Use(by: warriorWithCharge, on: new Target(99999));

            const int elapsedTime = 1000;
            time.Pass(elapsedTime);

            charge.RemainingCooldownInMillis.Should().Be(charge.CooldownInMillis - elapsedTime);
        }
    }

}
