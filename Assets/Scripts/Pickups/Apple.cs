using UnityEngine;

public class Apple : Pickups
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3;

    LevelGenerator levelGenerator;

   public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
