using Godot;
using System.Linq;

public partial class Score : Control
{
	private Node _allCoins;
	private Label _coinsCount;

	public int coinsScore = 0;

	public override void _Ready()
	{
		_allCoins = GetNode<Node>("%Coins");
		_coinsCount = GetNode<Label>("%CoinsCount");

		foreach (Coin coin in _allCoins.GetChildren().Cast<Coin>())
		{
			coin.CoinCollected += UpdateScore;
		}
	}

	public void UpdateScore()
	{
		coinsScore += 1;
		_coinsCount.Text = "Coins : " + coinsScore.ToString();
	}
}
