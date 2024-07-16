using FluentAssertions;

namespace Models.Tests.Skills
{
    public class SpecificSkills
    {
        [Test]
        public void SDAdfasdf()
        {
            var time = new Time();
            var target = Character.Warrior;

            Skill.Slam(time).Use(on: target);

            target.Health.Should().BeLessThan(Character.Warrior.Health);
        }
    }
}
