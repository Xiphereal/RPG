using Models.Characters;

namespace Models.Abilities
{
    public class Ability
    {
        private const int TwentySeconds = 20000;

        private Time time;

        public string Name { get; set; } = "Undefined";

        public int CooldownInMillis { get; set; }

        private int remainingCooldownInMillis;
        private readonly HashSet<IEffect> effects = [];

        public static Ability Slam(Time time)
        {
            Ability ability = new(time) { Name = nameof(Slam) };
            ability
                .With(new AttackPowerCoefficientBasedDamage()
                {
                    Coefficient = 0.35
                })
                .Consuming(howMuch: 20);

            return ability;
        }

        public static Ability Charge(Time time)
        {
            Ability ability = new(time)
            {
                Name = nameof(Charge),
                CooldownInMillis = TwentySeconds,
            };

            Root root = new Root();
            root.AffectedBy(time);

            ability
                .With(new AttackPowerCoefficientBasedDamage()
                {
                    Coefficient = 0.21
                })
                .With(root)
                .With(new ResourceGeneration() { Value = 20 });

            return ability;
        }

        public int RemainingCooldownInMillis
        {
            get => remainingCooldownInMillis;
            set => remainingCooldownInMillis = Math.Clamp(value, min: 0, max: CooldownInMillis);
        }

        public int ResourceConsumption { get; private set; }

        public Ability(Time time)
        {
            AffectedBy(time);
        }

        public bool Available()
        {
            return RemainingCooldownInMillis == 0;
        }

        public void Use(Character by, Target? on = null)
        {
            if (!Available())
                throw new ArgumentException();

            effects.Apply(by, on);

            by.ConsumeResource(ResourceConsumption);

            PutOnCooldown();
        }

        private void PutOnCooldown()
        {
            RemainingCooldownInMillis = CooldownInMillis;
        }

        public static Ability SubdueBy(Time time)
        {
            return new Ability(time);
        }

        public Ability With(IEffect effect)
        {
            effect.AffectedBy(time);
            effects.Add(effect);

            return this;
        }

        public Ability Consuming(int howMuch)
        {
            ResourceConsumption = howMuch;

            return this;
        }

        public void AffectedBy(Time time)
        {
            this.time = time;
            this.time.Tick += (_, _) => RemainingCooldownInMillis--;

            foreach (var effect in effects)
                effect.AffectedBy(time);
        }
    }
}