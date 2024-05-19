using Godot;

public partial class Coin : Area2D
{
	[Signal]
	public delegate void CoinCollectedEventHandler();

	private AnimationPlayer _pickUp;

	public override void _Ready()
	{
		_pickUp = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public void OnBodyEntered(CharacterBody2D body)
	{
		if (body is Player)
		{
			EmitSignal(SignalName.CoinCollected);
			_pickUp.Play("PickUp");
		}
	}
}
