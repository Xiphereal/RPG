namespace Models
{
    public class Warrior : Character
    {
        internal Warrior()
        {
            var time = new Time();

            Abilities.Add(Skill.Slam(time));
        }
    }
}