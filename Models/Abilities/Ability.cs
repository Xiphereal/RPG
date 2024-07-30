using Models.Characters;

namespace Models.Abilities
{
    public class Ability
    {
        private const int OneSecond = 1000;
        private const int FifteenSeconds = 15000;
        private const int TwentySeconds = 20000;

        public string Name { get; set; } = "Undefined";

        public int CooldownInMillis { get; set; }

        private int remainingCooldownInMillis;
        public int RemainingCooldownInMillis
        {
            get => remainingCooldownInMillis;
            set => remainingCooldownInMillis = Math.Clamp(value, min: 0, max: CooldownInMillis);
        }

        private readonly HashSet<IEffect> effects = [];

        public static Ability Slam()
        {
            Ability ability = new() { Name = nameof(Slam) };
            ability
                .With(new AttackPowerCoefficientBasedDamage()
                {
                    Coefficient = 0.35
                })
                .Consuming(howMuch: 20);

            return ability;
        }

        public static Ability Charge()
        {
            Ability ability = new()
            {
                Name = nameof(Charge),
                CooldownInMillis = TwentySeconds,
            };

            var root = new Root(durationInMilis: OneSecond);

            ability
                .With(new AttackPowerCoefficientBasedDamage()
                {
                    Coefficient = 0.21
                })
                .With(root)
                .With(new ResourceGeneration() { Value = 20 });

            return ability;
        }

        public static Ability BattleShout()
        {
            Ability ability = new()
            {
                Name = "Battle Shout",
                CooldownInMillis = FifteenSeconds,
            };

            return ability;
        }

        public int ResourceConsumption { get; private set; }

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

        public Ability With(IEffect effect)
        {
            effects.Add(effect);

            return this;
        }

        public Ability Consuming(int howMuch)
        {
            ResourceConsumption = howMuch;

            return this;
        }

        public void PassTime(int howMuch = 1)
        {
            for (int i = 0; i < howMuch; i++)
                RemainingCooldownInMillis--;

            foreach (var effect in effects)
                effect.PassTime(howMuch);
        }


    }
}