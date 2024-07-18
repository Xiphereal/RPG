using Models.Characters;

namespace Models.Abilities
{
    public abstract class Debuff : IEffect
    {
        public bool IsExpired { get; set; }
        public int DurationInMilis { get; set; }

        public void AffectedBy(Time time)
        {
            time.Tick += (_, _) =>
            {
                DurationInMilis--;

                IsExpired = DurationInMilis <= 0;
            };
        }

        public abstract void Apply(Target on, Character? by = null);

        public abstract void Expire(Target on);
    }
}