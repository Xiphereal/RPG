
namespace Models
{
    public class Time
    {
        public event EventHandler Tick;

        public void Pass(int howMuch = 1)
        {
            for (int i = 0; i < howMuch; i++)
                Tick(this, EventArgs.Empty);
        }
    }
}