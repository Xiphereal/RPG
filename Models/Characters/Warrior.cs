namespace Models.Characters
{
    public class Warrior : Character
    {
        public Resource Rage => resource;

        internal Warrior(int health) : base(health, Resource.Rage)
        {
            Abilities.Add(Models.Abilities.Ability.Slam());
        }

        public override void LevelUp()
        {
            base.LevelUp();

            switch (Level)
            {
                case 2:
                    Abilities.Add(Models.Abilities.Ability.Charge());
                    break;
            }
        }

        public void GenerateRage(int howMuch)
        {
            resource.Gain(howMuch);
        }
    }
}