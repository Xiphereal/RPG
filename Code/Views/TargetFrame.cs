using Godot;
using Models.Characters;

public partial class TargetFrame : Control
{
    public Target Target { private get; set; }

    public override void _Process(double delta)
    {
        GetNode<Label>("%Level").Text = Target.Level.ToString();
        GetNode<ProgressBar>("%Health").Value = Target.Health;
        GetNode<ProgressBar>("%Resource").Value = 0;
    }
}
