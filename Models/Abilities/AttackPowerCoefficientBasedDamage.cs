using Models.Characters;

namespace Models.Abilities
{
    public class AttackPowerCoefficientBasedDamage : IEffect
    {
        public bool IsExpired { get; set; }
        public double Coefficient { get; set; }

        public void PassTime(int howMuch)
        {
        }

        public void Apply(Target on, Character? by = null)
        {
            on.Take((by!.AttackPower * Coefficient).ToInt());
        }

        public void Expire(Target on)
        {
            throw new NotImplementedException();
        }
    }
}