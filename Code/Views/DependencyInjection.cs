using Godot;
using Models.Characters;

public partial class DependencyInjection : Control
{
    public override void _Ready()
    {
        Warrior warrior = Character.Warrior;

        // lvl 2, with Charge.
        warrior.LevelUp();

        GetNode<CharacterFrame>("YourCharacterFrame").Warrior = warrior;
        GetNode<ActionBar>("ActionBar").Warrior = warrior;
    }
}
