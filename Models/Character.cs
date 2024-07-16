namespace Models
{
    public class Character
    {
        public static Character Warrior => new();
        public int Health { get; set; } = 500;
    }
}