using Godot;
using System;

public partial class Enemy : Node2D
{
	private const int enemySpeed = 60;
	private int direction = 1;

	private AnimatedSprite2D enemySprite;
	private RayCast2D rayCastRight;
	private RayCast2D rayCastLeft;

	public override void _Ready()
	{
		rayCastRight = GetNode<RayCast2D>("RayCastRight");
		rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		enemySprite = GetNode<AnimatedSprite2D>("EnemySprite");
	}

	public override void _Process(double delta)
	{
		if (rayCastLeft.IsColliding())
		{
			direction = 1;
			enemySprite.FlipH = false;
		}
		if (rayCastRight.IsColliding())
		{
			direction = -1;
			enemySprite.FlipH = true;
		}
		Vector2 position = Position;
		position.X += direction * enemySpeed * (float)delta;
		Position = position;
	}
}
