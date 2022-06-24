using Godot;
using System;

public class EnvironmentHandler : Node
{
    [Export]
    public PackedScene[] _Meteor;

    private Node _environmentRoot;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _environmentRoot =  GetNodeOrNull("/root/Main/Environment");
        if(_environmentRoot != null)
		{
			//TODO Create projectile root node if not there
			//TODO Create Logger class and functions
			GD.Print("Got Environment Root Node");
		}        
    }

    public void SpawnMeteor(Vector2 spawnPos, Vector2 direction, string meteorVariant, int meteorDesign)
    {
        var meteor = (Meteor)_Meteor[meteorDesign].Instance();
        _environmentRoot.AddChild(meteor);
        meteor.GlobalPosition = spawnPos;
        meteor.SetDirection(direction);
        meteor.SetVariant(meteorVariant);
    }

}
