﻿using Models.Characters;

namespace Models.Abilities
{
    internal class ResourceGeneration : IEffect
    {
        public int Value { get; set; }
        public bool IsExpired { get; set; }

        public void AffectedBy(Time time)
        {
        }

        public void Apply(Target on, Character? by = null)
        {
            by!.GenerateResource(Value);
        }

        public void Expire(Target on)
        {
        }
    }
}