using Models.Skills;

namespace Models.Characters
{
    public class Character : Target
    {
        public Character(int health) : base(health)
        {
        }

        public static Character Warrior => new Warrior(health: 500);
        public ISet<Skill> Abilities { get; set; } = new HashSet<Skill>();
        public int AttackPower { get; set; } = 20;
        public int Level { get; private set; } = 1;

        public void LevelUp()
        {
            Level++;
        }
    }
}