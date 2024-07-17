using FluentAssertions;
using Models.Characters;
using Models.Skills;

namespace Models.Tests.Skills
{
    public class SpecificSkills
    {
        [Test]
        public void SlamDealsDamageBasedOnAttackPower()
        {
            var time = new Time();
            var caster = Character.Warrior;
            var target = Character.Warrior;

            Skill.Slam(time).Use(by: caster, on: target);

            int damage = Character.Warrior.Health - target.Health;
            damage.Should().Be(ToInt(Character.Warrior.AttackPower * 0.35));
        }

        [Test]
        public void ChargeDealsDamageBasedOnAttackPower_AndRootsTarget()
        {
            // Arrange
            var time = new Time();
            var caster = Character.Warrior;
            var target = Character.Warrior;

            // Act
            Skill.Charge(time).Use(by: caster, on: target);

            // Assert
            int damage = Character.Warrior.Health - target.Health;
            damage.Should().Be(ToInt(Character.Warrior.AttackPower * 0.21));

            target.IsRooted.Should().BeTrue();
        }

        private int ToInt(double value)
        {
            return (int)Math.Round(value);
        }
    }
}
