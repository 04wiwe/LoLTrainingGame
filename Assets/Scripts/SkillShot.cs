using UnityEngine;
public class SkillShot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnOffset = 2f;
    public float projectileSpeed = 10f;
    public Camera mainCamera;
    public float cooldownTime = 0.5f;
    private float _cooldown = 0f;
    void Update()
    {
        _cooldown += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_cooldown >= cooldownTime)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Vector3 clickPoint = hit.point;
                    Vector3 playerPosition = transform.position;
                    clickPoint.y = playerPosition.y;
                    Vector3 direction = (clickPoint - playerPosition).normalized;
                    Vector3 spawnPosition = playerPosition + direction * spawnOffset;
                    GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                    projectile.GetComponent<Projectile>().Initialize(direction, projectileSpeed);
                }
                _cooldown = 0f;
            }
        }
    }
}