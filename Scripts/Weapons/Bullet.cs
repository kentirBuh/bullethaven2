using Godot;
using System;

public partial class Bullet : Area2D, Attack
{
    public float traveled_distance { get; set;  }
    [Export]
    public float max_distance { get; set;  }
    [Export]
    public float speed { get; set;  }
    [Export]
    public int damage { get; set;  }

    public override void _Ready()
    {
        traveled_distance = 0f;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Vector2.Right.Rotated(Rotation);
        Position += direction * speed * (float)delta;
        traveled_distance += speed * (float)delta;
        if (traveled_distance >= max_distance)
        {
            QueueFree();
        }
    }
    public void _on_body_entered(Node2D body)
    {
        GD.Print("Bullet hit " + body.Name);
        QueueFree();
        if (body.HasMethod("TakeDamage"))
        {
            body.Call("TakeDamage", damage);
        }
    }
}
