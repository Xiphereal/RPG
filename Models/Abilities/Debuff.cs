using Models.Characters;

namespace Models.Abilities
{
    public abstract class Debuff : IEffect
    {
        public bool IsExpired { get; set; }
        public int DurationInMilis { get; set; }
        public int RemainingDurationInMilis { get; set; }

        public void AffectedBy(Time time)
        {
            time.Tick += (_, _) =>
            {
                RemainingDurationInMilis--;

                IsExpired = RemainingDurationInMilis <= 0;
            };
        }
        public abstract void Tick(Target on);

        public void Apply(Target on, Character? by = null)
        {
            RemainingDurationInMilis = DurationInMilis;
            on.Apply(this);
        }

        public abstract void Expire(Target on);
    }
}