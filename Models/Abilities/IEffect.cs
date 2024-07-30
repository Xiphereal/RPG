using Models.Characters;

namespace Models.Abilities
{
    public interface IEffect
    {
        bool IsExpired { get; set; }

        void Apply(Target on, Character? by = null);
        void Expire(Target on);
        void PassTime(int howMuch);
    }
}
