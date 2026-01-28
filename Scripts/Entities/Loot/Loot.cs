using Godot;
using System;

public partial class Loot : Node
{
    public Sprite2D lootSprite;
    public string lootName;
    public int dropChance;

    public Loot(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}

public partial class XPOrb : Loot
{
 

    public XPOrb(string lootName, int dropChance) : base(lootName, dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
