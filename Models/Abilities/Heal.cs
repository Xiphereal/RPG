using Models.Characters;

namespace Models.Abilities
{
    public class Heal : IEffect
    {
        public int Value { get; set; }
        public bool IsExpired { get; set; }

        public void AffectedBy(Time time)
        {
        }

        public void Apply(Target on, Character? by = null)
        {
            on.Heal(Value);
        }

        public void Expire(Target on)
        {
            throw new NotImplementedException();
        }
    }
}