namespace Models.Tests.Skills
{
    using FluentAssertions;
    using Models;
    using Models.Skills;

    public class CooldownTests
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
        public void StartWithNoCooldown()
        {
            var time = new Time();
            new Skill(time) { CooldownInMillis = 1000 }
                .RemainingCooldownInMillis
                .Should().Be(0);
        }

        [Test]
        public void Using_aSkill_PutsItOnCooldown()
        {
            var time = new Time();
            var sut = new Skill(time) { CooldownInMillis = 1000 };

            sut.Use();

            sut.RemainingCooldownInMillis.Should().Be(sut.CooldownInMillis);
        }

        [Test]
        public void PassingTimeReducesCooldown_Linearly()
        {
            var time = new Time();
            var sut = new Skill(time) { CooldownInMillis = 1000 };
            sut.Use();

            const int ticks = 3;
            time.Pass(howMuch: ticks);
            sut.RemainingCooldownInMillis.Should().Be(sut.CooldownInMillis - ticks);
        }

        [Test]
        public void CooldownNeverUnderflows()
        {
            var time = new Time();
            var sut = new Skill(time) { CooldownInMillis = 1 };
            sut.Use();

            const int ticks = 3;
            time.Pass(howMuch: ticks);
            sut.RemainingCooldownInMillis.Should().Be(0);
        }

        [Test]
        public void CanNotBeUsedOnCooldown()
        {
            var time = new Time();
            var sut = new Skill(time) { CooldownInMillis = 1000 };

            sut.Available().Should().BeTrue();
            sut.Use();

            sut.Available().Should().BeFalse();
        }

        [Test]
        public void AreAvailableAgainAfterCooldown()
        {
            var time = new Time();
            var sut = new Skill(time) { CooldownInMillis = 1000 };
            sut.Use();
            time.Pass(howMuch: sut.CooldownInMillis);

            sut.Available().Should().BeTrue();
        }
    }
}