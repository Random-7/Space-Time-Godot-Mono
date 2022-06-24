using Godot;
using System;

public class Enemy : KinematicBody2D
{
    private Player player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player = (Player)GetNodeOrNull("/root/Main/Player");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (player != null)
            LookAt(player.GlobalPosition);
    }

    public void SetEnemyDesign(string enemyDesign)
    {
        var animatedSprite = (AnimatedSprite)GetNodeOrNull("AnimatedSprite");
        if (animatedSprite == null) return;

        animatedSprite.Play(enemyDesign);
    }

}
