
namespace Models
{
    public class Skill
    {
        private Time time;
        private int remainingCooldown;

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
        public int RemainingCooldown
        {
            get => remainingCooldown;
            set => remainingCooldown = Math.Clamp(value, 0, CooldownInMillis);
        }

        public void Use()
        {
            RemainingCooldown = CooldownInMillis;
        }
    }
}