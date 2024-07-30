namespace Models.Tests.Abilities
{
    using FluentAssertions;
    using Models.Abilities;
    using Models.Characters;

    public class CooldownTests
    {
        [Test]
        public void HasUndefinedAsDefaultName()
        {
            new Ability().Name.Should().Be("Undefined");
        }

        [Test]
        public void CanHaveItsOwnName()
        {
            new Ability() { Name = "Any" }.Name.Should().Be("Any");
        }

        [Test]
        public void StartWithNoCooldown()
        {
            new Ability() { CooldownInMillis = 1000 }
                .RemainingCooldownInMillis
                .Should().Be(0);
        }

        [Test]
        public void Using_aSkill_PutsItOnCooldown()
        {
            var sut = new Ability() { CooldownInMillis = 1000 };

            sut.Use(by: Character.Warrior);

            sut.RemainingCooldownInMillis.Should().Be(sut.CooldownInMillis);
        }

        [Test]
        public void PassingTimeReducesCooldown_Linearly()
        {
            var sut = new Ability() { CooldownInMillis = 1000 };
            sut.Use(by: Character.Warrior);

            const int ticks = 3;
            sut.PassTime(howMuch: ticks);

            sut.RemainingCooldownInMillis.Should().Be(sut.CooldownInMillis - ticks);
        }

        [Test]
        public void CooldownNeverUnderflows()
        {
            var sut = new Ability() { CooldownInMillis = 1 };
            sut.Use(by: Character.Warrior);

            const int ticks = 3;
            sut.PassTime(howMuch: ticks);

            sut.RemainingCooldownInMillis.Should().Be(0);
        }

        [Test]
        public void CanNotBeUsedOnCooldown()
        {
            var sut = new Ability() { CooldownInMillis = 1000 };

            sut.Available().Should().BeTrue();
            sut.Use(by: Character.Warrior);

            sut.Available().Should().BeFalse();
        }

        [Test]
        public void AreAvailableAgainAfterCooldown()
        {
            var sut = new Ability() { CooldownInMillis = 1000 };
            sut.Use(by: Character.Warrior);

            sut.PassTime(howMuch: sut.CooldownInMillis);

            sut.Available().Should().BeTrue();
        }
    }
}