using Godot;
using System;

public partial class KillZone : Area2D
{
	Timer timer;

	public void OnBodyEntered(CharacterBody2D body)
	{
		timer = GetNode<Timer>("Timer");
		timer.Start();
	}

	public void OnTimerTimeout() {
		GetTree().ReloadCurrentScene();
	}
}
