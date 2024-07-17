﻿using Models.Characters;

namespace Models.Skills
{
    public static class EffectsExtensions
    {
        public static void Apply(
            this IEnumerable<IEffect> effects,
            Character? by,
            Target? on)
        {
            foreach (var effect in effects)
                effect.Apply(on, by);
        }
    }
}
