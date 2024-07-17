using FluentAssertions;
using Models.Characters;
using Models.Skills;

namespace Models.Tests.Skills
{
    public class EffectTests
    {
        [Test]
        public void DealDamageToTarget()
        {
            var damage = new Damage()
            {
                Value = 200
            };
            Skill skill = Skill.SubdueBy(new Time()).With(damage);
            var target = new Target(health: 200);

            skill.Use(on: target);

            target.Health.Should().Be(0);
        }

        [Test]
        public void HealsTarget()
        {
            var damage = new Heal()
            {
                Value = 200
            };
            Skill skill = Skill.SubdueBy(new Time()).With(damage);
            var target = new Target(health: 200);

            skill.Use(on: target);

            target.Health.Should().Be(400);
        }
    }
}
