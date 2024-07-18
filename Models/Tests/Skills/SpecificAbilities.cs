using FluentAssertions;
using Models.Abilities;
using Models.Characters;

namespace Models.Tests.Abilities
{
    public class SpecificAbilities
    {
        private const int OneSecond = 1000;

        [Test]
        public void SlamDealsDamageBasedOnAttackPower()
        {
            var time = new Time();
            var caster = Character.Warrior;
            var target = Character.Warrior;

            Ability.Slam(time).Use(by: caster, on: target);

            int damage = Character.Warrior.Health - target.Health;
            damage.Should().Be(ToInt(Character.Warrior.AttackPower * 0.35));
        }

        [Test]
        public void ChargeDealsDamageBasedOnAttackPower_AndRootsTargetFor1sec()
        {
            // Arrange
            var time = new Time();
            var caster = Character.Warrior;
            var target = Character.Warrior;
            target.AffectedBy(time);

            // Act
            Ability.Charge(time).Use(by: caster, on: target);

            // Assert
            int damage = Character.Warrior.Health - target.Health;
            damage.Should().Be(ToInt(Character.Warrior.AttackPower * 0.21));

            time.Pass();
            target.IsRooted.Should().BeTrue();

            time.Pass(OneSecond);
            target.IsRooted.Should().BeFalse();
        }

        private int ToInt(double value)
        {
            return (int)Math.Round(value);
        }
    }
}
