namespace Models.Tests
{
    using FluentAssertions;
    using Models;

    public class SkillTests
    {
        [Test]
        public void HasUndefinedAsDefaultName()
        {
            var time = new Time();
            new Skill(time).Name.Should().Be("Undefined");
        }

        [Test]
        public void CanHaveItsOwnName()
        {
            var time = new Time();
            new Skill(time) { Name = "Any" }.Name.Should().Be("Any");
        }

        [Test]
        public void StartWithLiveCooldown()
        {
            var time = new Time();
            new Skill(time) { CooldownInMillis = 1000 }
                .RemainingCooldown
                .Should().Be(0);
        }

        [Test]
        public void Using_aSkill_PutsItOnCooldown()
        {
            var time = new Time();
            var sut = new Skill(time) { CooldownInMillis = 1000 };

            sut.Use();

            sut.RemainingCooldown.Should().Be(sut.CooldownInMillis);
        }

        [Test]
        public void PassingTimeReducesCooldown()
        {
            var time = new Time();
            var sut = new Skill(time) { CooldownInMillis = 1000 };
            sut.Use();

            time.Pass();

            sut.RemainingCooldown.Should().BeLessThan(sut.CooldownInMillis);
        }
    }
}