﻿using Models.Skills;

namespace Models
{
    public class Character : Target
    {
        public Character(int health) : base(health)
        {
        }

        public static Character Warrior => new Warrior(health: 500);
        public ISet<Skill> Abilities { get; set; } = new HashSet<Skill>();
    }
}