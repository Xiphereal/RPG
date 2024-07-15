
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

        private int remainingCooldown;
        public int RemainingCooldown
        {
            get => remainingCooldown;
            set => remainingCooldown = Math.Clamp(value, min: 0, max: CooldownInMillis);
        }

        public bool Available()
        {
            return RemainingCooldown == 0;
        }

        public void Use()
        {
            RemainingCooldown = CooldownInMillis;
        }
    }
}