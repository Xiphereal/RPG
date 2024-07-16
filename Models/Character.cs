namespace Models
{
    public class Character
    {
        public static Character Warrior => new Warrior();
        public int Health { get; set; } = 500;
        public ISet<Skill> Abilities { get; set; } = new HashSet<Skill>();
    }
}