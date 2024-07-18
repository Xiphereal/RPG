using Models.Characters;

namespace Models.Abilities
{
    public class Damage : IEffect
    {
        public bool IsExpired { get; set; }
        public int Value { get; set; }
        public void AffectedBy(Time time)
        {
        }
        public void Apply(Target on, Character? by = null)
        {
            on.ReceiveDamage(Value);
        }

        public void Expire(Target on)
        {
            throw new NotImplementedException();
        }
    }
}