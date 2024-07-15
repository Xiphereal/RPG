namespace Models.Tests
{
    using FluentAssertions;
    using Models;

    public class SkillTests
    {
        [Test]
        public void HasUndefinedAsDefaultName()
        {
            new Skill().Name.Should().Be("Undefined");
        }

        [Test]
        public void CanHaveItsOwnName()
        {
            new Skill() { Name = "Any" }.Name.Should().Be("Any");
        }

        [Test]
        public void StartWithLiveCooldown()
        {
            new Skill() { CooldownInMillis = 1000 }
                .RemainingCooldown
                .Should().Be(0);
        }

        [Test]
        public void Using_aSkill_PutsItOnCooldown()
        {
            var sut = new Skill() { CooldownInMillis = 1000 };

            sut.Use();

            sut.RemainingCooldown.Should().Be(sut.CooldownInMillis);
        }
    }
}