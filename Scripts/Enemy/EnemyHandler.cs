using Godot;
using System;

public class EnemyHandler : Node
{
    [Export]
    PackedScene[] EnemyPrefabs;
    private Node _enemyRoot;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _enemyRoot = GetNodeOrNull("/root/Main/Enemies/");
        if (_enemyRoot != null)
        {  //TODO: Create Enemies node if null
            GD.Print("Got Enemy Root Node");
        }

    }
    public void SpawnEnemy(Vector2 spawnPos, int enemyType, string enemyDesign)
    {
        var enemy = (Enemy)EnemyPrefabs[enemyType].Instance();
        _enemyRoot.AddChild(enemy);
        enemy.GlobalPosition = spawnPos;
        enemy.SetEnemyDesign(enemyDesign);
    }
}
