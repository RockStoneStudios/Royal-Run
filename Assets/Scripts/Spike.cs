using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] GameObject player;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //player.ReducirSalud();
            Debug.Log("Te pinchaste conmigo");
        }
    }



}
