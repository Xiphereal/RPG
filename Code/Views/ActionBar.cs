using Godot;
using Models.Abilities;
using Models.Characters;
using System;
using System.Linq;

public partial class ActionBar : Control
{
    public Warrior Warrior { private get; set; }

    public override void _Process(double delta)
    {
        DisplayAbilitiesCDs();
    }

    private void DisplayAbilitiesCDs()
    {
        var buttons = GetNode("HBoxContainer").GetChildren();

        for (int i = 0; i < Warrior.Abilities.Count; i++)
        {
            var ability = Warrior.Abilities.ElementAt(i);

            buttons[i].GetNode<Control>("CD").Visible = ability.RemainingCooldownInMillis > 0;

            double remainingCooldownInSeconds =
                TimeSpan
                    .FromMilliseconds(ability.RemainingCooldownInMillis)
                    .TotalSeconds;
            buttons[i].GetNode<Control>("CD").GetChild<Label>(0).Text =
                ToInt(remainingCooldownInSeconds).ToString();
        }
    }

    private static int ToInt(double value)
    {
        return (int)Math.Round(value);
    }

    public void UseSlam()
    {
        Warrior.Abilities
            .First(x => x.Name == nameof(Ability.Slam))
            .Use(by: Warrior, on: new Target(health: 999999));
    }

    public void UseCharge()
    {
        Warrior.Abilities
            .First(x => x.Name == nameof(Ability.Charge))
            .Use(by: Warrior, on: new Target(health: 999999));
    }
}
