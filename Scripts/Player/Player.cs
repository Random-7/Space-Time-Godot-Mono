using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export]
	public float Speed = 100;
	[Export]
	public float fireRateDelay = 0.3f;
	
	private Vector2 Velocity = new Vector2(0,0);
	
	private float lastFireTime = 0.0f;
	private ProjectileHandler projectileHandler;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lastFireTime = fireRateDelay;
		projectileHandler = (ProjectileHandler)GetNode("/root/Main/Projectiles/ProjectileHandler");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{		
		if(Input.IsActionPressed("move_up"))
			Velocity += Vector2.Up;
		if(Input.IsActionPressed("move_down"))
			Velocity += Vector2.Down;
		if(Input.IsActionPressed("move_left"))
			Velocity += Vector2.Left;
		if(Input.IsActionPressed("move_right"))
			Velocity += Vector2.Right;

		Velocity = Velocity * Speed * delta;
	
		MoveAndCollide(Velocity);

		LookAt(GetGlobalMousePosition());

		if(Input.IsActionPressed("fire_1"))
		{
			if(lastFireTime > fireRateDelay)
			{
			lastFireTime = 0.0f;
			Fire();
			} 
			lastFireTime += delta;
		}
	}

	private void Fire()
	{
		var projectileSpawn = (Node2D)GetNodeOrNull("ProjectileSpawn");
		if (projectileSpawn != null)
		{
			var aimspot = GetGlobalMousePosition();
			projectileHandler.SpawnProjectile(projectileSpawn.GlobalPosition, projectileSpawn.GlobalPosition - aimspot.Normalized(),"Laser2", false);
		} else {
			GD.Print("No Fire Point found");
		}
	}
}
