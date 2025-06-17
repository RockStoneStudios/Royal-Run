using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    [SerializeField] float speedRotation = 80f;
    const string playerString = "Player";



    void Update()
    {
        transform.Rotate(0f, speedRotation * Time.deltaTime, 0f);
        Debug.Log("Hola");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup();
}


