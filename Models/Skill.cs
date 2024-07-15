
using Models.Skills;

namespace Models
{
    public class Skill
    {
        private Time time;

        public string Name { get; set; } = "Undefined";

        public int CooldownInMillis { get; set; }

        private int remainingCooldown;
        private readonly HashSet<Effect> effects = [];

        public int RemainingCooldown
        {
            get => remainingCooldown;
            set => remainingCooldown = Math.Clamp(value, min: 0, max: CooldownInMillis);
        }

        public Skill(Time time)
        {
            this.time = time;
            this.time.Tick += (_, _) => RemainingCooldown--;
        }

        public bool Available()
        {
            return RemainingCooldown == 0;
        }

        public void Use(Target? on = null)
        {
            if (!Available())
                throw new ArgumentException();

            foreach (var effect in effects)
            {
                effect.Apply(on);
            }

            RemainingCooldown = CooldownInMillis;
        }
        public static Skill SubdueBy(Time time)
        {
            return new Skill(time);
        }

        public Skill With(Effect effect)
        {
            this.effects.Add(effect);

            return this;
        }
    }
}