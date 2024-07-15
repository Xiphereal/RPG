namespace Models.Tests
{
    using FluentAssertions;
    using Models;

    public class SkillTests
    {
        [Test]
        public void HasUndefinedAsDefaultName()
        {
            Skill.Name.Should().Be("Undefined");
        }

        [Test]
        public void StartWithLiveCooldown()
        {
            new Skill() { CooldownInMillis = 1000 }
                .RemainingCooldown
                .Should().Be(0);
        }
    }
}