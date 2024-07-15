using Models.Skills;

namespace Models
{
    public static class EffectsExtensions
    {
        public static void Apply(this IEnumerable<IEffect> effects, Target? on)
        {
            foreach (var effect in effects)
                effect.Apply(on);
        }
    }
}
