using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

public partial class DeafultEnemy : CharacterBody2D, IGameEntity
{
    [Export]
    public string characterName { get; set; }
    [Export]
    public int healthPoints { get; set; }
    [Export]
    public float moveSpeed { get; set; }
    [Export]
    public CharacterBody2D playerReference;

    public override void _PhysicsProcess(double delta)
    {
        GetVelocityTowardPlayer();
        MoveAndSlide();
    }
    public void GetVelocityTowardPlayer()

    {
        Vector2 directionToPlayer = (playerReference.Position - Position).Normalized();
        Velocity = directionToPlayer * moveSpeed;
    }
    public void TakeDamage(int damageTaken)
    {
        GD.Print($"{characterName} took {damageTaken} damage.");
        healthPoints -= damageTaken;
        if (healthPoints <= 0)
        {
            HasDied();
        }
    }

    public void HasDied()
    {
        GD.Print($"{characterName} has died.");
        QueueFree();
    }

    public void AttackAction(IGameEntity enemy)
    {
        GD.Print($"{characterName} attacks {enemy.characterName}!");
        // Attack logic here
    }
}
