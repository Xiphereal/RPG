using Models.Abilities;

namespace Models.Characters
{
    public abstract class Character : Target
    {
        protected Resource resource;

        protected Character(int health, Resource resource) : base(health)
        {
            this.resource = resource;
        }

        public static Warrior Warrior => new Warrior(health: 500);
        public ISet<Ability> Abilities { get; set; } = new HashSet<Ability>();
        public int AttackPower { get; set; } = 20;
        public int Level { get; private set; } = 1;

        public virtual void LevelUp()
        {
            Level++;
        }

        public void ConsumeResource(int howMuch)
        {
            this.resource.Consume(howMuch);
        }
    }
}