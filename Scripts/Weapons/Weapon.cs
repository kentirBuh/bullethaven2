using Godot;
using System;

public partial interface Weapon
{
    public float fireRate { get; set; }
    public float timeSinceLastAttack { get; set; }
    public PackedScene attackScene { get; set; }

    

    public void Attack(Vector2 position, float rotation) { }

    public void ChangeFireRate(float newFireRate) { }
}
