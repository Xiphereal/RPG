
using Models.Skills;

namespace Models
{
    public class Skill
    {
        private Time time;

        public string Name { get; set; } = "Undefined";

        public int CooldownInMillis { get; set; }

        private int remainingCooldownInMillis;
        private readonly HashSet<IEffect> effects = [];

        private Resource resource = Resource.None;
        private int resourceConsumption;

        public static Skill Slam(Time time)
        {
            Skill skill = new(time) { Name = nameof(Slam) };
            skill.With(new AttackPowerCoefficientBasedDamage()
            {
                Coefficient = 0.35
            });

            return skill;
        }

        public int RemainingCooldownInMillis
        {
            get => remainingCooldownInMillis;
            set => remainingCooldownInMillis = Math.Clamp(value, min: 0, max: CooldownInMillis);
        }

        public Skill(Time time)
        {
            this.time = time;
            this.time.Tick += (_, _) => RemainingCooldownInMillis--;
        }

        public bool Available()
        {
            return RemainingCooldownInMillis == 0;
        }

        public void Use(Character? by = null, Target? on = null)
        {
            if (!Available())
                throw new ArgumentException();

            effects.Apply(by, on);

            this.resource.Consume(this.resourceConsumption);

            PutOnCooldown();
        }

        private void PutOnCooldown()
        {
            RemainingCooldownInMillis = CooldownInMillis;
        }

        public static Skill SubdueBy(Time time)
        {
            return new Skill(time);
        }

        public Skill With(IEffect effect)
        {
            this.effects.Add(effect);

            return this;
        }

        public Skill Using(int howMuch, Resource resource)
        {
            this.resource = resource;
            this.resourceConsumption = howMuch;

            return this;
        }
    }
}