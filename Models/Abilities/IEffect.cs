using Models.Characters;

namespace Models.Abilities
{
    public interface IEffect
    {
        void AffectedBy(Time time);
        void Apply(Target on, Character? by = null);
    }
}
