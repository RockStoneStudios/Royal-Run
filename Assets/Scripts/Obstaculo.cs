using System.Threading;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private  PlayerController playerController;
    private  ObstacleSpawner obstacleSpawner;
    Rigidbody rb;


    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Start()
    {
       
        playerController = FindAnyObjectByType<PlayerController>();
        obstacleSpawner = FindAnyObjectByType<ObstacleSpawner>();

    }

    void Update()
    {
        if (transform.position.z + 5 < playerController.gameObject.transform.position.z)
        {
            obstacleSpawner.DesactivateObstacle(gameObject);
        }
    }
    private void FixedUpdate() {
        
    }
}
