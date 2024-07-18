using Models.Characters;

namespace Models.Abilities
{
    public interface IEffect
    {
        bool IsExpired { get; set; }

        void AffectedBy(Time time);
        void Apply(Target on, Character? by = null);
    }
}
