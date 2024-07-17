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

        private int ToInt(double value)
        {
            return (int)Math.Round(value);
        }
    }
}
