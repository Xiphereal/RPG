
namespace Models
{
    public class Time
    {
        public event EventHandler Tick;

        public void Pass()
        {
            Tick(this, EventArgs.Empty);
        }
    }
}