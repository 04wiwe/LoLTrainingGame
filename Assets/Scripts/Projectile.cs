using UnityEngine;
public class Projectile : MonoBehaviour
{
    private Vector3 _moveDirection;
    private float _speed;
    public float cooldwon = 0f;
    public void Initialize(Vector3 direction, float projectileSpeed)
    {
        _moveDirection = direction;
        _speed = projectileSpeed;
    }
    void Update()
    {
        cooldwon += Time.deltaTime;
        if (cooldwon >= 1)
        {
            Destroy(gameObject);
        }
        transform.position += _moveDirection * (_speed * Time.deltaTime);
    }
}