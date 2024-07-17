using Models.Abilities;

namespace Models.Characters
{
    public class Warrior : Character
    {
        internal Warrior(int health) : base(health)
        {
            var time = new Time();

            Abilities.Add(Ability.Slam(time));
        }

        public override void LevelUp()
        {
            base.LevelUp();

            switch (Level)
            {
                case 2:
                    Abilities.Add(Ability.Charge(new Time()));
                    break;
            }
        }
    }
}