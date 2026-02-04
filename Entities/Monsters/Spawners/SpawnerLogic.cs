using Godot;
using System;

public partial class SpawnerLogic : Node2D
{
    [Export] 
    public CharacterBody2D PlayerScene { get; set; }
    [Export] 
    public PackedScene Enemy { get; set; }

    protected float spawnDistance = 550f;
    protected int enemyCounter = 0;

    public void SpawnEnemy(Vector2 spawnPosition)
    {
        var enemyInstance = Enemy.Instantiate<DeafultEnemy>();
        enemyInstance.GlobalPosition = spawnPosition;
        enemyInstance.playerReference = PlayerScene;
        GetTree().Root.AddChild(enemyInstance);
        GD.Print($"Spawned enemy at {spawnPosition}");
    }

    public Vector2 GetSpawnPosition()
    {
        var random = new Random();
        float angle = (float)(random.NextDouble() * Math.PI * 2);
        Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnDistance;
        return PlayerScene.GlobalPosition + offset;
    }

    public void SpawnMultipleEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 spawnPos = GetSpawnPosition();
            SpawnEnemy(spawnPos);
        }
    }
    public void _on_spawnTimer_timeout()
    {
        enemyCounter++;
        GD.Print($"Spawning {enemyCounter%10} enemies.");
        SpawnMultipleEnemies(enemyCounter%10);
    }

}
