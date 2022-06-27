using Godot;
using System;

public class Projectile : Area2D
{
	[Export]
	public float Speed = 50;
	private Vector2 direction = Vector2.Up;
	private bool isEnemy;
	private bool isFired;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var projectile = (AnimatedSprite)GetNode("AnimatedSprite");
		if(isEnemy)
			projectile.Play("Laser1");
		else
			projectile.Play("Laser0");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (isFired)
			GlobalTranslate(direction * Speed * delta);
			
	}

	void _on_Projectile_body_entered(PhysicsBody2D body)
	{
		GD.Print("Hit Object: " + body.Name);
		//TODO Calculate hit, deal damage, destory etc.
		QueueFree();
	}

	public void SetDirectionAndRotation(Vector2 newDirection, float rotation)
	{
		direction = newDirection;
		RotationDegrees = rotation;
		isFired = true;
	}
	public void SetEnemy(bool isAnEnemy)
	{
		isEnemy = isAnEnemy;
	}
}
