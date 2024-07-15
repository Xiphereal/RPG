
namespace Models
{
    public class Skill
    {
        private Time time;

        public Skill(Time time)
        {
            this.time = time;
            this.time.Tick += this.Time_Tick;
        }

        private void Time_Tick(object? sender, EventArgs e)
        {
            RemainingCooldown--;
        }

        public string Name { get; set; } = "Undefined";

        public int CooldownInMillis { get; set; }
        public int RemainingCooldown { get; set; }

        public void Use()
        {
            RemainingCooldown = CooldownInMillis;
        }
    }
}