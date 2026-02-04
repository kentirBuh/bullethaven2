using Godot;
using System;
using System.ComponentModel;
using System.Diagnostics;

public partial class PlayerCharacter : CharacterBody2D, IGameEntity
{
    [Export]
    public string characterName { get; set; }
    [Export]
    public int maxHealthPoints { get; set; }
    [Export]
    public int healthPoints { get; set; }
            
    [Export]
    public int manaPoints { get; set; }
    [Export]
    public int attackValue { get; set; }
    [Export]
    public float attackSpeed { get; set; }


    public int Level { get; set; }

    //[Export]
    //public IBehavior behavior { get; protected set; }

    [Export]
    public float moveSpeed { get; set; }
    [Export]
    public int XPerience { get; set; }

    public PlayerCharacter( int hp, int mana, float speed, int attack, float attackSpd)
{
    maxHealthPoints = hp;
    healthPoints = hp;
    manaPoints = mana;
    moveSpeed = speed;
    attackValue = attack;
    attackSpeed = attackSpd;
    XPerience = 0;
    Level = 1;
}



//functions

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
        // no logic for death yet
    }

    public void LevelUp()
    {
        Level += 1;
        XPerience = 0;
        GD.Print($"{characterName} has leveled up to Level {Level}!");
    }

    public void GainExperience(int xpGained)
    {
        XPerience += xpGained;
        if( XPerience >= LevelThresholdFunction() )
        {
            LevelUp();
        }
        GD.Print($"{characterName} gained {xpGained} XP. Total XP: {XPerience}");
    }

    public double LevelThresholdFunction()
    {
        return Math.Pow(2,Level) * 100;
    }

}
