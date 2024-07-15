

namespace Models.Skills
{
    public class Target
    {
        public int Health { get; private set; }
        public Target(int health)
        {
            this.Health = health;
        }

        public void ReceiveDamage(int value) => Health -= value;

        public void Heal(int value) => Health += value;
    }
}