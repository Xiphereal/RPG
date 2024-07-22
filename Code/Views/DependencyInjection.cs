using Godot;
using Models.Characters;

public partial class DependencyInjection : Control
{
    private Models.Time time;

    public override void _Ready()
    {
        Warrior warrior = Character.Warrior;
        // lvl 2, with Charge.
        warrior.LevelUp();

        time = new Models.Time();
        warrior.AffectedBy(time);

        GetNode<CharacterFrame>("YourCharacterFrame").Warrior = warrior;
        GetNode<ActionBar>("ActionBar").Warrior = warrior;
    }

    public void TimeTicked()
    {
        time.Pass();
    }
}
