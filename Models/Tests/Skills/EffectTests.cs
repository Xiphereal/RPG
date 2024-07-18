using FluentAssertions;
using Models.Abilities;
using Models.Characters;

namespace Models.Tests.Abilities
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
            Ability ability = Ability.SubdueBy(new Time()).With(damage);
            var target = new Target(health: 200);

            ability.Use(on: target);

            target.Health.Should().Be(0);
        }

        [Test]
        public void HealsTarget()
        {
            var heal = new Heal()
            {
                Value = 200
            };
            Ability ability = Ability.SubdueBy(new Time()).With(heal);
            var target = new Target(health: 200);

            ability.Use(on: target);

            target.Health.Should().Be(400);
        }

        [Test]
        public void Characters_CanBeDebuffed()
        {
            var character = Character.Warrior;
            var root = new Root()
            {
                DurationInMilis = 1000
            };

            character.Apply(root);

            character.Debuffs.Should().Contain(root);
            character.IsRooted.Should().BeTrue();
        }

        [Test]
        public void Debuffs_ExpireOverTime()
        {
            var root = new Root()
            {
                DurationInMilis = 1000
            };
            Time time = new Time();
            root.AffectedBy(time);

            time.Pass(root.DurationInMilis);

            root.IsExpired.Should().BeTrue();
        }

        [Test]
        public void CharacterDebuffs_AreRemovedWhenExpired_ThusTheirEffectVanished()
        {
            // Arrange
            var root = new Root()
            {
                DurationInMilis = 1000
            };
            Time time = new Time();
            root.AffectedBy(time);

            var character = Character.Warrior;
            character.Apply(root);
            character.AffectedBy(time);
            character.IsRooted.Should().BeTrue();

            // Act
            time.Pass(root.DurationInMilis);

            // Assert
            character.Debuffs.Should().BeEmpty();
            character.IsRooted.Should().BeFalse();
        }
    }
}
