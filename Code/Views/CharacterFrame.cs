using Godot;
using Models.Characters;

public partial class CharacterFrame : Control
{
    private readonly Warrior character;

    public CharacterFrame()
    {
        character = Character.Warrior;
    }

    public override void _Process(double delta)
    {
        GetNode<Label>("%Level").Text = character.Level.ToString();
        GetNode<ProgressBar>("%Health").Value = character.Health;
        GetNode<ProgressBar>("%Resource").Value = character.Rage.Value;
    }
}
