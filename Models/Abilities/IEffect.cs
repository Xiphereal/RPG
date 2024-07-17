using Models.Characters;

namespace Models.Abilities
{
    public interface IEffect
    {
        void Apply(Target on, Character? by = null);
    }
}
