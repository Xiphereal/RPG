using Models.Abilities;

namespace Models.Characters
{
    public class Warrior : Character
    {
        public Resource Rage => resource;

        internal Warrior(int health) : base(health)
        {
            var time = new Time();
            resource = new Rage();

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

        public void GenerateRage(int howMuch)
        {
            resource.Gain(howMuch);
        }
    }
}