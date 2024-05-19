using Godot;
using System;

public partial class KillZone : Area2D
{
	Timer timer;

	public void OnBodyEntered(CharacterBody2D body)
	{
		timer = GetNode<Timer>("Timer");
		Engine.TimeScale = 0.6;
		body.GetNode<CollisionShape2D>("PlayerCollision").QueueFree();
		timer.Start();
	}

	public void OnTimerTimeout()
	{
		Engine.TimeScale = 1;
		GetTree().ReloadCurrentScene();
	}
}
