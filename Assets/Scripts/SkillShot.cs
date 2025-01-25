using UnityEngine;

public class SkillShot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnOffset = 2f;
    public float projectileSpeed = 10f;
    public Camera mainCamera;
    public float cooldownTime = 0.5f;
    private float _cooldown;

    private void Update()
    {
        _cooldown += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q))
            if (_cooldown >= cooldownTime)
            {
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    var clickPoint = hit.point;
                    var playerPosition = transform.position;
                    clickPoint.y = playerPosition.y;
                    var direction = (clickPoint - playerPosition).normalized;
                    var spawnPosition = playerPosition + direction * spawnOffset;
                    var projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                    projectile.GetComponent<Projectile>().Initialize(direction, projectileSpeed);
                }

                _cooldown = 0f;
            }
    }
}