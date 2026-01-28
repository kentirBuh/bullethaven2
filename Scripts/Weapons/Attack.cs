using Godot;
using System;

public partial interface Attack
{
    
    public float traveled_distance { get; set;  }
    public float max_distance { get; set;  }
    public float speed { get; set;  }
    public int damage { get; set;  }

    
    public void on_body_entered(Node2D body) {}
}
