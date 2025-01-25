using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float collisionRadius = 0.5f;
    private GameObject player;

    private void Start()
    {
        var playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null) player = playerMovement.gameObject;
    }

    private void Update()
    {
        if (player)
        {
            var direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * (speed * Time.deltaTime);
        }

        CheckCollisions();
    }

    private void CheckCollisions()
    {
        if (player && Vector3.Distance(transform.position, player.transform.position) <= collisionRadius)
        {
            GameManager.Instance.GameOver();
            Destroy(gameObject);
            return;
        }

        var projectiles = FindObjectsOfType<Projectile>();
        foreach (var projectile in projectiles)
            if (Vector3.Distance(transform.position, projectile.transform.position) <= collisionRadius)
            {
                Destroy(projectile.gameObject);
                Destroy(gameObject);
                DestroyEnemy();
                return;
            }
    }

    public void DestroyEnemy()
    {
        var playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats) playerStats.AddScore(1);
    }
}