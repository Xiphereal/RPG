using Models.Characters;

namespace Models.Skills
{
    internal class Root : IEffect
    {
        public void Apply(Target on, Character? by = null)
        {
            on.Root();
        }
    }
}