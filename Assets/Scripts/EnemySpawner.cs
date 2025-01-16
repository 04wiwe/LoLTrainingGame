using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRadiusMin = 5f;
    public float spawnRadiusMax = 15f;
    public float spawnInterval = 2f;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }
    private void SpawnEnemy()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(spawnRadiusMin, spawnRadiusMax);
        Vector3 spawnPosition = player.position + new Vector3(randomDirection.x, 0, randomDirection.y) * randomDistance;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}