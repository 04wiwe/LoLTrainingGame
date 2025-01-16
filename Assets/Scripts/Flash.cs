using UnityEngine;
public class TeleportSkill : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float teleportDistance = 5f;
    public float cooldownTime = 5f;
    private float _cooldown = 0f;
    void Update()
    {
        _cooldown += Time.deltaTime;
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_cooldown >= cooldownTime)
                {
                    Vector3 forwardDirection = transform.forward;
                    Vector3 teleportTarget = transform.position + forwardDirection * teleportDistance;
                    if (Physics.Raycast(transform.position, forwardDirection, out RaycastHit hit, teleportDistance))
                    {
                        teleportTarget = hit.point - forwardDirection * 0.5f;
                    }
                    transform.position = teleportTarget;
                    if (Vector3.Distance(teleportTarget, playerMovement.hitPoint) < teleportDistance)
                    {
                        playerMovement.hitPoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
                    }
                    _cooldown = 0f;
                }
            }
        }
    }
}