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
            Resource resource = Resource.Energy;
            resource.Value.Should().Be(resource.MaxValue);
            var sut = Ability
                .SubdueBy(time)
                .Using(20, resource);

            sut.Use();

            resource.Value.Should().BeLessThan(resource.MaxValue);
        }
    }
}
