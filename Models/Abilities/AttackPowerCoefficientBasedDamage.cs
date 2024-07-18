using Models.Characters;

namespace Models.Abilities
{
    public class AttackPowerCoefficientBasedDamage : IEffect
    {
        public bool IsExpired { get; set; }
        public double Coefficient { get; set; }

        public void AffectedBy(Time time)
        {
        }

        public void Apply(Target on, Character? by = null)
        {
            on.ReceiveDamage(ToInt(by!.AttackPower * Coefficient));
        }

        private int ToInt(double value)
        {
            return (int)Math.Round(value);
        }

        public void Expire(Target on)
        {
            throw new NotImplementedException();
        }
    }
}