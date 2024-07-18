using Models.Characters;

namespace Models.Abilities
{
    public class Heal : IEffect
    {
        private Time? time;
        public int Value { get; set; }
        public bool IsExpired { get; set; }

        public void AffectedBy(Time time)
        {
            this.time = time;
        }


        public void Apply(Target on, Character? by = null)
        {
            on.Heal(Value);
        }
    }
}