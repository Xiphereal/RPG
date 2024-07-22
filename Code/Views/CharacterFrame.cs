using Godot;
using Models.Characters;

public partial class CharacterFrame : Control
{
    public Warrior Warrior { private get; set; }

    public override void _Process(double delta)
    {
        GetNode<Label>("%Name").Text = Warrior.Name;
        GetNode<Label>("%Level").Text = Warrior.Level.ToString();
        GetNode<ProgressBar>("%Health").Value = Warrior.Health;
        GetNode<ProgressBar>("%Resource").Value = Warrior.Rage.Value;
    }
}
