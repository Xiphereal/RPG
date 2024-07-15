
namespace Models.Skills
{
    public class Effect
    {
        public int Value { get; set; }

        public void Apply(Target on)
        {
            on.ReceiveDamage(Value);
        }
    }
}