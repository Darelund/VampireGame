using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> projectiles = new();

    public List<GameObject> GetProjectileList => projectiles;

    private static ProjectileManager instance;


    public static ProjectileManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }


    
    public void UpdateAllProjectiles()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].GetComponent<Projectile>().UpdateProjectile();
            if (!projectiles[i].GetComponent<Projectile>().IsAlive)
            {
                Destroy(projectiles[i].gameObject);
                projectiles.RemoveAt(i);
                i--;
            }
        }
    }
    public void ToggleSimulationForProjectiles(bool dontPause)
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].GetComponent<Rigidbody2D>().simulated = dontPause;
        }
    }
}
