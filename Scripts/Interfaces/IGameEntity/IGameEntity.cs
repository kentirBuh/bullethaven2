using Godot;
using System;

public partial interface IGameEntity
{
public string characterName { get; set; }
public int healthPoints { get; set; }
public float moveSpeed { get; set; }
public void TakeDamage(int damageTaken);
public void HasDied();

}
