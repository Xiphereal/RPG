using Models.Characters;

namespace Models.Abilities
{
    public class Ability
    {
        private Time time;

        public string Name { get; set; } = "Undefined";

        public int CooldownInMillis { get; set; }

        private int remainingCooldownInMillis;
        private readonly HashSet<IEffect> effects = [];

        private int resourceConsumption;

        public static Ability Slam(Time time)
        {
            Ability ability = new(time) { Name = nameof(Slam) };
            ability
                .With(new AttackPowerCoefficientBasedDamage()
                {
                    Coefficient = 0.35
                })
                .Cost(howMuch: 20);

            return ability;
        }

        public static Ability Charge(Time time)
        {
            Ability ability = new(time) { Name = nameof(Charge) };

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

        public Ability(Time time)
        {
            this.time = time;
            this.time.Tick += (_, _) => RemainingCooldownInMillis--;
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

            by.ConsumeResource(resourceConsumption);

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

        public Ability Cost(int howMuch)
        {
            resourceConsumption = howMuch;

            return this;
        }
    }
}