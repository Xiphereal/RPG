using Godot;
using Models.Abilities;
using Models.Characters;
using System.Linq;

public partial class ActionBar : Control
{
    private readonly Warrior warrior;

    public ActionBar()
    {
        warrior = Character.Warrior;

        // lvl 2, with Charge.
        warrior.LevelUp();
    }

    public void UseSlam()
    {
        warrior.Abilities
            .First(x => x.Name == nameof(Ability.Slam))
            .Use(by: warrior, on: new Target(health: 999999));
    }

    public void UseCharge()
    {
        warrior.Abilities
            .First(x => x.Name == nameof(Ability.Charge))
            .Use(by: warrior, on: new Target(health: 999999));
    }
}
