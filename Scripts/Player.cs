using Godot;

public partial class Player : CharacterBody2D
{
	private AnimatedSprite2D _playerAnim;
	private AudioStreamPlayer2D _jumpSound;
	private const float _speed = 150f;
	private const float _jumpVelocity = -300f;
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		_playerAnim = GetNode<AnimatedSprite2D>("PlayerSpriteAnim");
		_jumpSound = GetNode<AudioStreamPlayer2D>("JumpSound");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += _gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = _jumpVelocity;
			_jumpSound.Playing = true;
		}

		float direction = Input.GetAxis("left", "right");

		// Flip Sprite
		if (direction > 0) _playerAnim.FlipH = false;
		else if (direction < 0) _playerAnim.FlipH = true;

		// Play animations
		if (!IsOnFloor())
		{
			_playerAnim.Play("jump");
		}
		else
		{
			if (direction != 0) _playerAnim.Play("run");
			else if (direction == 0) _playerAnim.Play("idle");
		}

		// Apply movement
		if (direction != 0)
		{
			velocity.X = direction * _speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, _speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
