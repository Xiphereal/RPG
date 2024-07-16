namespace Models
{
    public class Warrior : Character
    {
        internal Warrior(int health) : base(health)
        {
            var time = new Time();

            Abilities.Add(Skill.Slam(time));
        }
    }
}