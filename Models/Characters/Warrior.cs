using Models.Skills;

namespace Models.Characters
{
    public class Warrior : Character
    {
        internal Warrior(int health) : base(health)
        {
            var time = new Time();

            Abilities.Add(Skill.Slam(time));
        }

        public override void LevelUp()
        {
            base.LevelUp();

            switch (Level)
            {
                case 2:
                    Abilities.Add(Skill.Charge(new Time()));
                    break;
            }
        }
    }
}