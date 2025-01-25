using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 hitPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
                hitPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }

        if (Vector3.Distance(transform.position, hitPoint) > 0.1f)
        {
            var direction = hitPoint - transform.position;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                var targetRotation = Quaternion.LookRotation(direction);
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