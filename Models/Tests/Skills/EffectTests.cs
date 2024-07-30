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
                HowMuch = 200
            };
            Ability ability = new Ability().With(damage);
            var target = new Target(health: 200);

            ability.Use(by: Character.Warrior, on: target);

            target.Health.Should().Be(0);
        }

        [Test]
        public void HealsTarget()
        {
            var heal = new Heal()
            {
                Value = 200
            };
            Ability ability = new Ability().With(heal);
            var target = new Target(health: 200);

            ability.Use(by: Character.Warrior, on: target);

            target.Health.Should().Be(400);
        }

        [Test]
        public void Characters_CanBeDebuffed()
        {
            var character = Character.Warrior;
            var root = new Root(durationInMilis: 1000);

            character.Apply(root);

            character.Debuffs.Should().Contain(root);
            character.PassTime();
            character.IsRooted.Should().BeTrue();
        }

        [Test]
        public void Debuffs_ExpireOverTime()
        {
            var root = new Root(durationInMilis: 1000);
            var time = new Time();
            root.AffectedBy(time);

            time.Pass(root.RemainingDurationInMilis);

            root.IsExpired.Should().BeTrue();
        }

        [Test]
        [Category("Regression")]
        public void DebuffDurationOnApplication_IsItsFullDuration()
        {
            const int initial = 1000;
            var root = new Root(durationInMilis: initial);
            var time = new Time();
            root.AffectedBy(time);
            time.Pass(root.RemainingDurationInMilis);

            root.Apply(on: Target.Invencible());

            root.RemainingDurationInMilis.Should().Be(initial);
        }

        [Test]
        public void CharacterDebuffs_AreRemovedWhenExpired_ThusTheirEffectVanished()
        {
            // Arrange
            var root = new Root(durationInMilis: 2);

            var character = Character.Warrior;
            character.Apply(root);

            character.PassTime();
            character.IsRooted.Should().BeTrue();

            // Act
            character.PassTime(root.RemainingDurationInMilis);

            // Assert
            character.Debuffs.Should().BeEmpty();
            character.IsRooted.Should().BeFalse();
        }
    }
}
