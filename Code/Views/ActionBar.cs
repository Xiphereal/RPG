using Godot;
using Models.Abilities;
using Models.Characters;
using System.Linq;

public partial class ActionBar : Control
{
    public Warrior Warrior { private get; set; }

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
