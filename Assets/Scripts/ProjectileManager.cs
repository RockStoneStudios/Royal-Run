using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;
    private int currentIndex = 0;

    void Start()
    {
        // Activa solo el primero
        ActivateProjectile(currentIndex);
    }

    public void NotifyProjectileDestroyed()
    {
        currentIndex++;
        if (currentIndex < projectiles.Length)
        {
            ActivateProjectile(currentIndex);
        }
    }

    private void ActivateProjectile(int index)
    {
        if (projectiles[index] != null)
        {
            projectiles[index].SetActive(true);
        }
    }
}
