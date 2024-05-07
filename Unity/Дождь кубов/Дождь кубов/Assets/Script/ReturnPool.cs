using System.Collections;
using UnityEngine;

public class ReturnPool : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private float _minTimeDestroy = 2;
    [SerializeField] private float _maxTimeDestroy = 6;

    private WaitForSeconds _wait;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cube cube))
        {
            _wait = new WaitForSeconds(Random.Range(_minTimeDestroy, _maxTimeDestroy));
            StartCoroutine(Delay(cube));
        }
    }

    private IEnumerator Delay(Cube cube)
    {
        yield return _wait;
        _pool.PutObject(cube);
    }
}
