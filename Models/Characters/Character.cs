using Models.Abilities;

namespace Models.Characters
{
    public abstract class Character : Target
    {
        protected Resource resource;

        public int Experience { get; private set; }
        public int ExperienceRequiredForLevelUp { get; private set; } = 100;

        protected Character(int health, Resource resource) : base(health)
        {
            this.resource = resource;
        }

        public static Warrior Warrior => new Warrior(health: 500);
        public ISet<Ability> Abilities { get; set; } = new HashSet<Ability>();
        public int AttackPower { get; set; } = 20;

        public Ability Ability(string which)
        {
            return Abilities.First(x => x.Name == which);
        }

        public virtual void LevelUp()
        {
            Level++;
            Experience = 0;
            ExperienceRequiredForLevelUp += ExperienceRequiredForLevelUp;
        }

        public override void PassTime(int howMuch = 1)
        {
            base.PassTime(howMuch);

            foreach (var ability in Abilities)
                ability.PassTime(howMuch);
        }

        public void GainExp(int gain)
        {
            Experience += gain;

            if (Experience >= ExperienceRequiredForLevelUp)
                LevelUp();
        }

        public void ConsumeResource(int howMuch)
        {
            this.resource.Consume(howMuch);
        }

        public void GenerateResource(int howMuch)
        {
            this.resource.Gain(howMuch);
        }

        public bool HasAvailable(string abilityName)
        {
            return Ability(abilityName).ResourceConsumption <= resource.Value
                && Ability(abilityName).Available();
        }
    }
}