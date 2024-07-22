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
            buttons[i].GetNode<Control>("CD").GetChild<Label>(0).Text =
                TimeSpan.FromMilliseconds(ability.RemainingCooldownInMillis).TotalSeconds.ToString();
        }
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
