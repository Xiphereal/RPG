using Godot;
using System.Linq;

public partial class BuffsDebuffs : HBoxContainer
{
    public override void _Process(double delta)
    {
        Visible = GetChildren().Any();
    }
}
