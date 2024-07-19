using FluentAssertions;
using Models.Abilities;
using Models.Characters;

namespace Models.Tests.Abilities
{
    public class SpecificAbilities
    {
        private const int OneSecond = 1000;

        [Test]
        public void Slam_DealsDamageBasedOnAttackPower()
        {
            var time = new Time();
            var caster = Character.Warrior;
            var target = Character.Warrior;

            Ability.Slam(time).Use(by: caster, on: target);

            int damage = Character.Warrior.Health - target.Health;
            damage.Should().Be(ToInt(Character.Warrior.AttackPower * 0.35));
        }

        [Test]
        public void Slam_Consumes20Rage()
        {
            var time = new Time();
            var caster = Character.Warrior;
            var target = Character.Warrior;
            caster.GenerateRage(100);

            Ability.Slam(time).Use(by: caster, on: target);

            caster.Rage.Value.Should().Be(80);
        }

        [Test]
        public void Charge_DealsDamageBasedOnAttackPower_AndRootsTargetFor1sec()
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

        [Test]
        public void Charge_Generates20Rage()
        {
            // Arrange
            var time = new Time();
            var caster = Character.Warrior;
            var target = Character.Warrior;
            target.AffectedBy(time);
            var previusRage = caster.Rage.Value;

            // Act
            Ability.Charge(time).Use(by: caster, on: target);

            // Assert
            caster.Rage.Value.Should().BeGreaterThan(previusRage);
        }

        private int ToInt(double value)
        {
            return (int)Math.Round(value);
        }
    }
}
