using Models.Abilities;

namespace Models.Characters
{
    public class Character : Target
    {
        public Character(int health) : base(health)
        {
        }

        public static Character Warrior => new Warrior(health: 500);
        public ISet<Ability> Abilities { get; set; } = new HashSet<Ability>();
        public int AttackPower { get; set; } = 20;
        public int Level { get; private set; } = 1;
        public List<IEffect> Debuffs { get; set; } = [];

        public void AffectedBy(Time time)
        {
            time.Tick += (_, _) => Debuffs.RemoveAll(x => x.IsExpired);
        }

        public void Apply(IEffect debuff)
        {
            Debuffs.Add(debuff);
        }

        public virtual void LevelUp()
        {
            Level++;
        }
    }
}