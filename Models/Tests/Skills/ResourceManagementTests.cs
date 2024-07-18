using FluentAssertions;
using Models.Abilities;
using Models.Characters;

namespace Models.Tests.Abilities
{
    public class ResourceManagementTests
    {
        [Test]
        public void ConsumesResources()
        {
            var time = new Time();
            var sut = Ability
                .SubdueBy(time)
                .Cost(20);
            var caster = Character.Warrior;
            caster.GenerateRage(100);

            sut.Use(by: caster);

            caster.Rage.Value.Should().BeLessThan(Resource.Rage.MaxValue);
        }
    }
}
