using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float cooldwon;
    private Vector3 _moveDirection;
    private float _speed;

    private void Update()
    {
        cooldwon += Time.deltaTime;
        if (cooldwon >= 1) Destroy(gameObject);
        transform.position += _moveDirection * (_speed * Time.deltaTime);
    }

    public void Initialize(Vector3 direction, float projectileSpeed)
    {
        _moveDirection = direction;
        _speed = projectileSpeed;
    }
}