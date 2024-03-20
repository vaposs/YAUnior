using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _delay;
    [SerializeField] ObjectPool _objectPool;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            _objectPool.GetObject();
            yield return _wait;
        }
    }
}