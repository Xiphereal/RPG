using Models.Characters;

namespace Models.Abilities
{
    internal class Root : IEffect
    {
        public void Apply(Target on, Character? by = null)
        {
            on.Root();
        }
    }
}