using Godot;
using System;

public partial class Cowboy :  PlayerCharacter, IGameEntity
{

    public Cowboy() : base( 150, 10, 50, 20, 0.5f)
    {
        characterName = "Cowboy";
        healthPoints = 150;
        manaPoints = 10;
        moveSpeed = 100;
    }

}

