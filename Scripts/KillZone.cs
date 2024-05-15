using Godot;
using System;

public partial class KillZone : Area2D
{
	public void OnBodyEntered(CharacterBody2D body)
	{
		if (body is Player) body.QueueFree();
	}
}
