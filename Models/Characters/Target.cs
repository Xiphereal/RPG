
namespace Models.Characters
{
    public class Target
    {
        public int Health { get; private set; }
        public bool IsRooted { get; private set; }
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
    }
}