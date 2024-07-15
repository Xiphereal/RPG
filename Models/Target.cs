
namespace Models.Skills
{
    public class Target
    {
        public int Life { get; set; }

        public void ReceiveDamage(int value)
        {
            Life -= value;
        }
    }
}