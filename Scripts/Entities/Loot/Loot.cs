using Godot;
using System;

public partial interface ILoot
{
    public string lootName { get; set; }
    public int dropChance { get; set; }

    
}

