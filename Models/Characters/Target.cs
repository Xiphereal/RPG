using Models.Abilities;

namespace Models.Characters
{
    public class Target
    {
        public int Health { get; private set; }
        public bool IsRooted { get; private set; }
        public List<Debuff> Debuffs { get; set; } = [];
        public Target(int health)
        {
            Health = health;
        }

        public void ReceiveDamage(int value) => Health -= value;

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

        public void AffectedBy(Time time)
        {
            time.Tick += (_, _) =>
            {
                Debuffs.ForEach(x => x.Tick(this));

                Debuffs
                    .Where(x => x.IsExpired).ToList()
                    .ForEach(x => x.Expire(on: this));
                Debuffs.RemoveAll(x => x.IsExpired);
            };
        }
    }
}