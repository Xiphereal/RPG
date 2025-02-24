﻿using FluentAssertions;
using FluentAssertions.Extensions;
using Models.Abilities;
using Models.Characters;

namespace Models.Tests.Abilities
{
    public class SpecificAbilities
    {
        private const int OneSecond = 1000;
        private const int HalfSecond = OneSecond / 2;

        [Test]
        public void Slam_DealsDamageBasedOnAttackPower()
        {
            var caster = Character.Warrior;
            var target = Character.Warrior;

            Ability.Slam().Use(by: caster, on: target);

            int damage = Character.Warrior.Health - target.Health;
            damage.Should().Be((Character.Warrior.AttackPower * 0.35).ToInt());
        }

        [Test]
        public void Slam_Consumes20Rage()
        {
            var caster = Character.Warrior;
            var target = Character.Warrior;
            caster.GenerateRage(100);

            Ability.Slam().Use(by: caster, on: target);

            caster.Rage.Value.Should().Be(80);
        }

        [Test]
        public void Charge_DealsDamageBasedOnAttackPower_AndRootsTargetFor1sec()
        {
            // Arrange
            var caster = WarriorWithCharge();
            var target = Character.Warrior;

            Ability sut = caster.Ability("Charge");

            // Act
            sut.Use(by: caster, on: target);

            // Assert
            int damage = Character.Warrior.Health - target.Health;
            damage.Should().Be((Character.Warrior.AttackPower * 0.21).ToInt());

            target.PassTime();
            target.IsRooted.Should().BeTrue();

            target.PassTime(HalfSecond);
            target.IsRooted.Should().BeTrue();
            target.PassTime(HalfSecond);
            target.IsRooted.Should().BeFalse();
        }

        private static Warrior WarriorWithCharge()
        {
            // Arrange
            var caster = Character.Warrior;
            caster.LevelUp();
            return caster;
        }

        [Test]
        public void Charge_Generates20Rage()
        {
            // Arrange
            var caster = Character.Warrior;
            var target = Character.Warrior;
            var previusRage = caster.Rage.Value;

            // Act
            Ability.Charge().Use(by: caster, on: target);

            // Assert
            caster.Rage.Value.Should().BeGreaterThan(previusRage);
        }

        [Test]
        public void Charge_Has20secCooldown()
        {
            Ability.Charge()
                .CooldownInMillis
                .Should().Be(20.Seconds().TotalMilliseconds.ToInt());
        }

        [Test]
        public void BattleShout_IncreasesOwnAttackPower()
        {
            Warrior caster = Character.Warrior;
            caster.LevelUpTo(10);

            Ability.BattleShout().Use(by: caster);

            caster.AttackPower.Should().BeGreaterThan(Character.Warrior.AttackPower);
        }

        [Test]
        public void BattleShout_Has15secCooldown()
        {
            Ability.BattleShout()
                .CooldownInMillis
                .Should().Be(15.Seconds().TotalMilliseconds.ToInt());
        }
    }
}
