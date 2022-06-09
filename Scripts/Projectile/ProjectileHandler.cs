using Godot;
using System;

public class ProjectileHandler : Node
{
	public PackedScene _Projectile = (PackedScene)GD.Load("res://Prefab/Projectiles/Projectile.tscn");

	private Node _projectileRoot;

	public override void _Ready()
	{
		_projectileRoot = GetNode("/root/Main/Projectiles/");
	}

	public void SpawnProjectile(Vector2 spawnPos, Vector2 direction, string animation, bool isEnemy)
	{
		var projectile = (Projectile)_Projectile.Instance();
		_projectileRoot.AddChild(projectile);
		projectile.GlobalPosition = spawnPos;
		projectile.SetDirection(direction);
		projectile.SetEnemy(isEnemy);
	}
}
