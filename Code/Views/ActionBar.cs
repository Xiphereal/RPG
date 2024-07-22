using Godot;
using Godot.Collections;
using Models.Abilities;
using Models.Characters;
using System;
using System.Linq;

public partial class ActionBar : Control
{
    public Warrior Warrior { private get; set; }
    public Target Target { private get; set; }

    public override void _Process(double delta)
    {
        DisplayAbilitiesCDs();
        DisableUnavailableAbilities();
    }

    private Array<Node> AllButtons => GetChild(0).GetChildren();


    private void DisplayAbilitiesCDs()
    {
        ForEachAbility((ability, index) =>
        {
            AllButtons[index].GetNode<Control>("CD").Visible =
                ability.RemainingCooldownInMillis > 0;

            double remainingCooldownInSeconds =
                TimeSpan
                    .FromMilliseconds(ability.RemainingCooldownInMillis)
                    .TotalSeconds;
            AllButtons[index].GetNode<Control>("CD").GetChild<Label>(0).Text =
                ToInt(remainingCooldownInSeconds).ToString();
        });
    }

    private void DisableUnavailableAbilities()
    {
        ForEachAbility((ability, index) =>
        {
            AllButtons[index].GetNode<Button>("Button").Disabled =
                !Warrior.HasAvailable(ability.Name);
        });
    }

    private void ForEachAbility(Action<Ability, int> action)
    {
        for (int i = 0; i < Warrior.Abilities.Count; i++)
        {
            var ability = Warrior.Abilities.ElementAt(i);

            action.Invoke(ability, i);
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
            .Use(by: Warrior, on: Target);
    }

    public void UseCharge()
    {
        Warrior.Abilities
            .First(x => x.Name == nameof(Ability.Charge))
            .Use(by: Warrior, on: Target);
    }
}
