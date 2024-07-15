
namespace Models.Skills
{
    public class Damage : IEffect
    {
        public int Value { get; set; }

        public void Apply(Target on)
        {
            on.ReceiveDamage(Value);
        }
    }
}