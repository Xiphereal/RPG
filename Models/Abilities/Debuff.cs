using Models.Characters;

namespace Models.Abilities
{
    public abstract class Debuff : IEffect
    {
        public bool IsExpired { get; set; }
        public int DurationInMilis { get; init; }
        public int RemainingDurationInMilis { get; private set; }

        protected Debuff(int durationInMilis)
        {
            DurationInMilis = durationInMilis;
            RemainingDurationInMilis = DurationInMilis;
        }

        public void PassTime(int howMuch = 1)
        {
            for (int i = 0; i < howMuch; i++)
                RemainingDurationInMilis--;

            IsExpired = RemainingDurationInMilis <= 0;
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