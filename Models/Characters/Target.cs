using Models.Abilities;

namespace Models.Characters
{
    public class Target
    {
        public static Target Invencible() => new(99999);

        public string Name { get; set; } = "Dummy";
        public int Health { get; private set; }
        public bool IsRooted { get; private set; }
        public List<Debuff> Debuffs { get; set; } = [];

        public int Level { get; protected set; } = 1;

        public Target(int health)
        {
            Health = health;
        }

        public void Take(int damage) => Health -= damage;

        public void Heal(int value) => Health += value;

        public void Root()
        {
            IsRooted = true;
        }

        public void Unroot()
        {
            IsRooted = false;
        }

        public void Apply(Debuff debuff)
        {
            Debuffs.Add(debuff);
        }

        public virtual void PassTime(int howMuch = 1)
        {
            for (int i = 0; i < howMuch; i++)
            {
                Debuffs.ForEach(x => x.Tick(this));
                Debuffs.ForEach(x => x.PassTime());

                Debuffs
                    .Where(x => x.IsExpired).ToList()
                    .ForEach(x => x.Expire(on: this));
                Debuffs.RemoveAll(x => x.IsExpired);
            }
        }
    }
}