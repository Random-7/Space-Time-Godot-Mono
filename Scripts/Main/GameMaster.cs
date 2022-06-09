using Godot;
using System;

public class GameMaster : Node
{

    private EnemyHandler enemyHandler;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        enemyHandler = (EnemyHandler)GetNodeOrNull("/root/Main/Enemies/EnemyHandler/");

        enemyHandler.SpawnEnemy(new Vector2(600,300), 0, "Enemy1");
        enemyHandler.SpawnEnemy(new Vector2(700,300), 1, "Enemy2");
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
