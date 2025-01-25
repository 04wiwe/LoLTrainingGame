using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    public Vector3 offset = new(0, 10, -10);
    public Transform player;
    private bool isFollowing;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            isFollowing = true;
        else
            isFollowing = false;
        if (Input.GetMouseButton(2))
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");
            var movement = new Vector3(-mouseX, 0, -mouseY);
            transform.position += movement * (moveSpeed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (isFollowing && player)
        {
            transform.position = player.position + offset;
            transform.LookAt(player);
        }
    }
}