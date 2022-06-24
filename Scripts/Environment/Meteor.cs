using Godot;
using System;

public class Meteor : KinematicBody2D
{
    [Export]
    private float Speed = 50.0f;
    [Export]
    private float RotationSpeed = 0.5f;
    [Export]
    private Vector2 Direction = Vector2.Down;
    private AnimatedSprite animatedSprite;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animatedSprite = (AnimatedSprite)GetNodeOrNull("AnimatedSprite");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        MoveAndCollide(Direction * Speed * delta);
        RotationDegrees = RotationDegrees + RotationSpeed;
    }



    public float GetSpeed() { return Speed; }   
    public void SetSpeed(float newSpeed) 
    {
        Speed = newSpeed;
    }

    public Vector2 GetDirection() { return Direction; }

    public void SetDirection(Vector2 newDirection ) 
    {
        Direction = newDirection;
    }

    public float GetRotationSpeed() { return RotationSpeed; }
    
    public void SetRotationSpeed(float newRotationSpeed) 
    {
        RotationSpeed = newRotationSpeed;
    }

    public void SetVariant(string meteorVariant)
    {
        animatedSprite.Play(meteorVariant);
    }

}
