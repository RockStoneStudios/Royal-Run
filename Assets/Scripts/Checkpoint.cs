using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float checkpointTimeExtension = 5f;

    GameManager gameManager;

    const string playerString = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Toco");
        if (other.CompareTag(playerString))
        {
            Debug.Log("Entre");
            gameManager.IncreaseTime(checkpointTimeExtension);
        }
    }
}
