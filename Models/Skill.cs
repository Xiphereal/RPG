
namespace Models
{
    public class Skill
    {
        public static string Name => "Undefined";

        public int CooldownInMillis { get; set; }
        public int RemainingCooldown { get; set; }

        public void Use()
        {
            RemainingCooldown = CooldownInMillis;
        }
    }
}