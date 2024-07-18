
namespace Models.Characters
{
    public class Rage : Resource
    {
        public Rage()
        {
            MaxValue = 100;
            Value = 0;
        }

        public void Generate(int howMuch)
        {
            Value += howMuch;
        }
    }
}