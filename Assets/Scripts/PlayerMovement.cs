using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 hitPoint;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                hitPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }
        if (Vector3.Distance(transform.position, hitPoint) > 0.1f)
        {
            Vector3 direction = hitPoint - transform.position;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }
            transform.position = Vector3.MoveTowards(
                new Vector3(transform.position.x, transform.position.y, transform.position.z), 
                new Vector3(hitPoint.x, transform.position.y, hitPoint.z), 
                Time.deltaTime * 5f
            );
        }
    }
}