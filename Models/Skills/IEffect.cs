using Models.Characters;

namespace Models.Skills
{
    public interface IEffect
    {
        void Apply(Target on, Character? by = null);
    }
}
