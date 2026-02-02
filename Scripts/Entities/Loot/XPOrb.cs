using Godot;
using System;

public partial class XPOrb : Area2D, ILoot
{
 
    public string lootName { get; set; }
    public int dropChance { get; set; }
    public int xpAmount { get; set; }

    
    public void _on_body_entered(Node body)
    {
        GD.Print($"Orb area entered by {body.Name}");
        if (body is PlayerCharacter player)
        {
            CallDeferred(nameof(DeferredPickup), player);
        }
    }
    public void _on_body_entered()
    {
        GD.Print("XP Orb collected!");
    }

    private void DeferredPickup(PlayerCharacter player)
    {
        player.GainExperience(xpAmount);
        GD.Print($"Player gained {xpAmount} XP!");
        QueueFree();
    }
}
