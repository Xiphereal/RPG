using Models.Characters;

namespace Models.Abilities
{
    public class Root : Debuff
    {
        public Root(int durationInMilis) : base(durationInMilis)
        {
        }

        public override void Tick(Target on)
        {
            on.Root();
        }
        public override void Expire(Target on)
        {
            on.Unroot();
        }
    }
}