using Models.Characters;

namespace Models.Abilities
{
    internal class AttackPowerVariation : IEffect
    {
        private readonly double percentage;

        public AttackPowerVariation(double ofPercentage)
        {
            percentage = ofPercentage;
        }

        public bool IsExpired { get; set; }

        public void Apply(Target on, Character by)
        {
            by.AttackPower += (by.AttackPower * percentage).ToInt();
        }

        public void Expire(Target on)
        {
            throw new NotImplementedException();
        }

        public void PassTime(int howMuch)
        {
        }
    }
}