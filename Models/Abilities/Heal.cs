using Models.Characters;

namespace Models.Abilities
{
    public class Heal : IEffect
    {
        public int Value { get; set; }

        public void Apply(Target on, Character? by = null)
        {
            on.Heal(Value);
        }
    }
}