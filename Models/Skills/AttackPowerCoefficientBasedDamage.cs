namespace Models.Skills
{
    public class AttackPowerCoefficientBasedDamage : IEffect
    {
        public double Coefficient { get; set; }

        public void Apply(Target on, Character? by = null)
        {
            on.ReceiveDamage(ToInt(by!.AttackPower * Coefficient));
        }

        private int ToInt(double value)
        {
            return (int)Math.Round(value);
        }
    }
}