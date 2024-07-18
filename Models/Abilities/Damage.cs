﻿using Models.Characters;

namespace Models.Abilities
{
    public class Damage : IEffect
    {
        public bool IsExpired { get; set; }
        private Time? time;
        public int Value { get; set; }
        public void AffectedBy(Time time)
        {
            this.time = time;
        }
        public void Apply(Target on, Character? by = null)
        {
            on.ReceiveDamage(Value);
        }
    }
}