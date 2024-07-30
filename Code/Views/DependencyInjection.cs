using Godot;
using Models.Characters;
using System.Collections.Generic;

public partial class DependencyInjection : Control
{
    private IList<Target> timeAffected = [];

    public override void _Ready()
    {
        Warrior warrior = Character.Warrior;
        warrior.Name = "You";
        // With Charge & Battle Shout.
        LevelUpTo(10, warrior);
        timeAffected.Add(warrior);

        GetNode<CharacterFrame>("YourCharacterFrame").Warrior = warrior;
        GetNode<ActionBar>("ActionBar").Warrior = warrior;

        var target = new Target(100);
        timeAffected.Add(target);
        GetNode<ActionBar>("ActionBar").Target = target;
        GetNode<TargetFrame>("TargetFrame").Target = target;
    }

    public void TimeTicked()
    {
        // This expects the Timer to tick every second.
        foreach (var target in timeAffected)
            target.PassTime(1000);
    }

    private static void LevelUpTo(int levels, Character who)
    {
        for (int i = 1; i < levels; i++)
            who.LevelUp();
    }
}