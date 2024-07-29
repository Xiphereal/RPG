using Godot;
using Models.Characters;

public partial class TargetFrame : Control
{
    public Target Target { private get; set; }

    public override void _Process(double delta)
    {
        UpdateASdfasdf();
        UpdateBuffs();
    }

    private void UpdateASdfasdf()
    {
        GetNode<Label>("%Name").Text = Target.Name;
        GetNode<Label>("%Level").Text = Target.Level.ToString();
        GetNode<ProgressBar>("%Health").Value = Target.Health;
        GetNode<ProgressBar>("%Resource").Value = 0;
    }

    private void UpdateBuffs()
    {
        RemoveAllBuffs();
        AddCurrentBuffs();
    }

    private void RemoveAllBuffs()
    {
        foreach (var buff in Buffs().GetChildren())
            Buffs().RemoveChild(buff);
    }

    private void AddCurrentBuffs()
    {
        foreach (var debuff in Target.Debuffs)
            Buffs()
                .AddChild(new TextureRect()
                {
                    ExpandMode = TextureRect.ExpandModeEnum.FitWidthProportional,
                    StretchMode = TextureRect.StretchModeEnum.KeepAspectCentered,
                    Texture = GD.Load<Texture2D>("res://Assets/SpellFrostStun.jpg")
                });
    }

    private BuffsDebuffs Buffs()
    {
        return GetNode<BuffsDebuffs>("%Buffs_Debuffs");
    }
}
