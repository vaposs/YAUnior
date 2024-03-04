using UnityEngine;

public class PlayerStalking: MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private int _damage;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetTransform.position, _speed * Time.deltaTime);
        FlipX();
    }

    private void FlipX()
    {
        if (transform.position.x > _targetTransform.transform.position.x)
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 0;
            transform.rotation = Quaternion.Euler(rotate);
        }
        else
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 180;
            transform.rotation = Quaternion.Euler(rotate);
        }
    }

    public int MakeDamage()
    {
        return _damage;
    }
}