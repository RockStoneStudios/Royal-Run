using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;
    const string hitString = "Hit";


    float cooldownTimer = 0f;
    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (cooldownTimer < collisionCooldown) return;
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);

        animator.SetTrigger(hitString);
        cooldownTimer = 0f;

    }
}
