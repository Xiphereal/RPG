using Models.Abilities;

namespace Models.Characters
{
    public class Warrior : Character
    {
        public Resource Rage => resource;

        internal Warrior(int health) : base(health, Resource.Rage)
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

        public void GenerateRage(int howMuch)
        {
            resource.Gain(howMuch);
        }
    }
}