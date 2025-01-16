using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    public Vector3 offset = new Vector3(0, 10, -10);
    public Transform player;
    private bool isFollowing = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }
        if (Input.GetMouseButton(2))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 movement = new Vector3(-mouseX, 0, -mouseY);
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