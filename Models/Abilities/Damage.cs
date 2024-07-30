using Models.Characters;

namespace Models.Abilities
{
    public class Damage : IEffect
    {
        public bool IsExpired { get; set; }
        public int HowMuch { get; set; }

        public void Apply(Target on, Character? by = null)
        {
            on.Take(HowMuch);
        }

        public void Expire(Target on)
        {
            throw new NotImplementedException();
        }

        public void PassTime(int howMuch)
        {
            throw new NotImplementedException();
        }
    }
}