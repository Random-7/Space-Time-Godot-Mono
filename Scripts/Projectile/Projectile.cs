using Godot;
using System;

public class Projectile : KinematicBody2D
{
	[Export]
	public float Speed = 50;
	

	private Vector2 direction = Vector2.Up;
	private bool isEnemy;

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
		MoveAndCollide(direction * Speed * delta);
	}

	public void SetDirection(Vector2 newDirection)
	{
		direction = newDirection;
	}
	public void SetEnemy(bool isAnEnemy)
	{
		isEnemy = isAnEnemy;
	}
}
