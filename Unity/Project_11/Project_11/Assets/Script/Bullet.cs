using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _timeToDie;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Transform _target;
    

    private void Start()
    {
        Destroy(gameObject, _timeToDie);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}