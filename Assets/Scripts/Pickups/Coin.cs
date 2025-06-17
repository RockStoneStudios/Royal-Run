using UnityEngine;

public class Coin : Pickups
{
    [SerializeField] int amount = 100;
    ScoreManagers scoreManagers;
    public  void Init(ScoreManagers scoreManagers)
    {
        this.scoreManagers = scoreManagers;
    }
    protected override void OnPickup()
    {
        scoreManagers.IncreaseScore(amount);
    }
}
