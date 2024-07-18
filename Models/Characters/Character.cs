using Models.Abilities;

namespace Models.Characters
{
    public class Character : Target
    {
        protected Resource resource = Resource.None;

        public Character(int health) : base(health)
        {
        }

        public static Warrior Warrior => new Warrior(health: 500);
        public ISet<Ability> Abilities { get; set; } = new HashSet<Ability>();
        public int AttackPower { get; set; } = 20;
        public int Level { get; private set; } = 1;

        public virtual void LevelUp()
        {
            Level++;
        }

        public void ConsumeResource(int resourceConsumption)
        {
            this.resource.Consume(resourceConsumption);
        }
    }
}