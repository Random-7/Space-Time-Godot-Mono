using Godot;
using System;

public class GameMaster : Node
{
    private EnvironmentHandler environmentHandler;
    private EnemyHandler enemyHandler;
    private PackedScene playerPrefab = (PackedScene)GD.Load("res://Prefab/Player/Player.tscn");


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        enemyHandler = (EnemyHandler)GetNodeOrNull("/root/Main/Enemies/EnemyHandler/");
        environmentHandler = (EnvironmentHandler)GetNodeOrNull("/root/Main/Environment/EnvironmentHandler");

        var player = (Player)playerPrefab.Instance();
        player.Scale = new Vector2(0.5f,0.5f);
        player.GlobalPosition = new Vector2(600,600);
        GetNode("/root/Main").AddChild(player);

        enemyHandler.SpawnEnemy(new Vector2(600,300), 0, "Enemy1");
        enemyHandler.SpawnEnemy(new Vector2(700,300), 1, "Enemy2");
        environmentHandler.SpawnMeteor(new Vector2(250,0), Vector2.Down, "Meteor4", 0);
        environmentHandler.SpawnMeteor(new Vector2(850,0), Vector2.Down, "Meteor3", 1);
        environmentHandler.SpawnMeteor(new Vector2(900,700), Vector2.Up, "Meteor3", 1);
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
