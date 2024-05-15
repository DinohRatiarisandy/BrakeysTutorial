using Godot;
using System;

public partial class Coin : Area2D
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(CharacterBody2D body)
	{
		if (body is Player)
		{
			QueueFree();
		}
	}
}
