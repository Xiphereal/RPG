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

        var target = new Target(100);
        GetNode<ActionBar>("ActionBar").Target = target;
        GetNode<TargetFrame>("TargetFrame").Target = target;
    }

    public void TimeTicked()
    {
        // This expects the Timer to tick every second.
        time.Pass(howMuch: 1000);
    }
}
