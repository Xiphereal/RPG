using Models.Characters;

namespace Models.Abilities
{
    public class Root : Debuff
    {
        public override void Apply(Target on, Character? by = null)
        {
            on.Root();
        }

        public override void Expire(Target on)
        {
            on.Unroot();
        }
    }
}