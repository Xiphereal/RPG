﻿using Models.Characters;

namespace Models.Abilities
{
    public class Root : IEffect
    {
        public int DurationInMilis { get; set; }

        public void AffectedBy(Time time)
        {
            time.Tick += (_, _) => DurationInMilis--;
        }

        public void Apply(Target on, Character? by = null)
        {
            on.Root();
        }
    }
}