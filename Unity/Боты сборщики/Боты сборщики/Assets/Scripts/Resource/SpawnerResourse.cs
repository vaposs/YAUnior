using System.Collections;
using UnityEngine;

public class SpawnerResourse : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private ResourcePool _resourcePool;

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
            _resourcePool.GetResource();
            yield return _wait;
        }
    }
}