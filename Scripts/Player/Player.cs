using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export]
	public float Speed = 100;
	[Export]
	public float fireRateDelay = 0.3f;
	private AnimatedSprite animatedSprite;	
	private Vector2 Velocity = new Vector2(0,0);
	private float lastFireTime = 0.0f;
	private ProjectileHandler projectileHandler;
	private int skinIndex = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lastFireTime = fireRateDelay;
		projectileHandler = (ProjectileHandler)GetNode("/root/Main/Projectiles/ProjectileHandler");
		animatedSprite = (AnimatedSprite)GetNodeOrNull("AnimatedSprite");

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

		if(Input.IsActionJustPressed("switch_skin"))
		{
			SwitchSkin();
		}
	}

	private void Fire()
	{
		var projectileSpawn = (Node2D)GetNodeOrNull("ProjectileSpawn");
		if (projectileSpawn != null)
		{
			var aimspot = GetGlobalMousePosition();
			projectileHandler.SpawnProjectile(projectileSpawn.GlobalPosition, projectileSpawn.GlobalPosition.DirectionTo(aimspot), this.RotationDegrees - 90, "Laser2", false);
		} else {
			GD.Print("No Fire Point found");
		}
	}

	private void SwitchSkin()
	{
		skinIndex += 1;
		string[] sprites = animatedSprite.Frames.GetAnimationNames();
		if(skinIndex >= sprites.Length)
		{
			skinIndex = 0;
		}
		if (animatedSprite != null)
		{
			animatedSprite.Play(sprites[skinIndex]);
			GD.Print("Setting player sprite: " + sprites[skinIndex] + " @ index " + skinIndex);
		}
	}
}
