using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.right;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float travelDistance = 5f;

    private Vector3 startPosition;
    private ProjectileManager manager;

    void OnEnable()
    {
        startPosition = transform.position;
        manager = FindObjectOfType<ProjectileManager>();
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(startPosition, transform.position) >= travelDistance)
        {
            NotifyAndDestroy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NotifyAndDestroy();
        }
    }

    private void NotifyAndDestroy()
    {
        manager.NotifyProjectileDestroyed();
        Destroy(gameObject);
    }
}
