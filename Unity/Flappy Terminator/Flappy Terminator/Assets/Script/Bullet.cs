using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _timeToDie;
    [SerializeField] private float _speed;

    private void Start()
    {
        Destroy(gameObject, _timeToDie);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed);
    }
}