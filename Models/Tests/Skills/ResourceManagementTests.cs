using FluentAssertions;
using Models.Skills;

namespace Models.Tests.Skills
{
    public class ResourceManagementTests
    {
        [Test]
        public void ConsumesResources()
        {
            var time = new Time();
            Resource resource = Resource.Energy;
            resource.Value.Should().Be(resource.MaxValue);
            var sut = Skill
                .SubdueBy(time)
                .Using(20, resource);

            sut.Use();

            resource.Value.Should().BeLessThan(resource.MaxValue);
        }
    }
}
