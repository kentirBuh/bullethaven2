using Godot;
using System;
using System.Diagnostics;

public partial class PlayerCharacter : CharacterBody2D, IGameEntity
{
    [Export]
    public string characterName { get; set; }
    [Export]
    public int healthPoints { get; set; }
            
    [Export]
    public int manaPoints { get; set; }

    //[Export]
    //public IBehavior behavior { get; protected set; }

    [Export]
    public float moveSpeed { get; set; }
    [Export]
    public int XPerience { get; set; }

    public PlayerCharacter( int hp, int mana, float speed)
{
    healthPoints = hp;
    manaPoints = mana;
    moveSpeed = speed;
    XPerience = 0;
}

    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("left","right","up","down");
        Velocity = inputDirection * moveSpeed ;
    }
    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide(); 
    }

    public void TakeDamage(int damageTaken)
    {
        healthPoints -= damageTaken;
        if (healthPoints <= 0)
        {
            HasDied();
        }
    }

    public void HasDied()
    {
        GD.Print($"{characterName} has died.");
        // Additional death logic here
    }

}
