using Godot;
using System;

public class ProjectileHandler : Node
{
	public PackedScene _Projectile = (PackedScene)GD.Load("res://Prefab/Projectiles/Projectile.tscn");

	private Node _projectileRoot;

	public override void _Ready()
	{
		_projectileRoot = GetNodeOrNull("/root/Main/Projectiles/");
		if(_projectileRoot != null)
		{
			//TODO Create projectile root node if not there
			//TODO Create Logger class and functions
			GD.Print("Got Projectile Root Node");
		}
	}

	public void SpawnProjectile(Vector2 spawnPos, Vector2 direction, float rotation, string animation, bool isEnemy)
	{
		var projectile = (Projectile)_Projectile.Instance();
		_projectileRoot.AddChild(projectile);
		projectile.GlobalPosition = spawnPos;
		projectile.SetEnemy(isEnemy);	
		projectile.SetDirectionAndRotation(direction.Normalized(), rotation );

		if(!isEnemy)
		{
			projectile.CollisionMask = 2; // Collide with Enemy
		} else {
			projectile.CollisionMask = 1; // Collide with Player
		}

		// Set is fired here
	}
}
