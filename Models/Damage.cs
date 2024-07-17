namespace Models.Skills
{
    public class Damage : IEffect
    {
        public int Value { get; set; }

        public void Apply(Target on, Character? by = null)
        {
            on.ReceiveDamage(Value);
        }
    }
}