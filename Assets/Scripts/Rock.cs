
using Unity.Cinemachine;
using UnityEngine;


public class Rock : MonoBehaviour
{
    [SerializeField] AudioSource rockSound;
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] float collisionCooldown = 1f;
    CinemachineImpulseSource impulseSource;


    float collisionTimer = 0f;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        
    }

    void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collisionTimer < collisionCooldown) return;

        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        // impulseSource.GenerateImpulseWithForce(force, 5f);
        CollisionFX(collision);
        collisionTimer = 0f;
    }

    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        rockSound.Play();
    }
}