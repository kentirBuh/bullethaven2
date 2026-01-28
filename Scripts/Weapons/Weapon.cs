using Godot;
using System;
using System.ComponentModel;

public partial interface Weapon
{
    //public int numberOfWeapons { get; set; }
    public float fireRate { get; set; }
    public float timeSinceLastAttack { get; set; }
    public PackedScene attackScene { get; set; }


    public void Attack(Vector2 position, float rotation) { }

    public void ChangeFireRate(float newFireRate) { }
}
