
namespace Models
{
    public class Skill
    {
        public string Name { get; set; } = "Undefined";

        public int CooldownInMillis { get; set; }
        public int RemainingCooldown { get; set; }

        public void Use()
        {
            RemainingCooldown = CooldownInMillis;
        }
    }
}