using Godot;
using System;
using System.Diagnostics;

public partial class Gun : Area2D, Weapon
{
    [Export]
    public float fireRate { get; set; } = 0.5f;
    public float timeSinceLastAttack { get; set; } = 0f;
    [Export]
    public PackedScene attackScene { get; set; }

    public override void _Ready()
    {
        attackScene = GD.Load<PackedScene>("res://Objects/bullet.tscn");
        var shootTimer = GetNode<Timer>("%ShootTimer");
        shootTimer.WaitTime = fireRate;
        shootTimer.Start();
    }
    public override void _PhysicsProcess(double delta)
    {
        var overlappingBodies = GetOverlappingBodies();
        if (overlappingBodies.Count > 0)
        {
            var targetEnemy = overlappingBodies[0];
            LookAt(targetEnemy.GlobalPosition);
        }
    }
        public void ChangeFireRate(float newFireRate)
    {
        fireRate = newFireRate;
        var shootTimer = GetNode<Timer>("%ShootTimer");
        shootTimer.WaitTime = fireRate;
    }


    public void Attack()
    {
        var bulletInstance = attackScene.Instantiate<Bullet>();
        bulletInstance.GlobalPosition = GetNode<Marker2D>("%ShootingPoint").GlobalPosition;
        bulletInstance.GlobalRotation = GetNode<Marker2D>("%ShootingPoint").GlobalRotation;

        GetNode<Marker2D>("%ShootingPoint").AddChild(bulletInstance);
    }
    public void _on_timer_timeout()
    {
        GD.Print("Shooting");
        Attack();
    }
}