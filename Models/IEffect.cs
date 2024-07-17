using Models.Skills;

namespace Models
{
    public interface IEffect
    {
        void Apply(Target on, Character? by = null);
    }
}
