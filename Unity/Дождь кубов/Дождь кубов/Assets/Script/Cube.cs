using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _minTimeDestroy = 2;
    [SerializeField] private float _maxTimeDestroy = 6;

    private WaitForSeconds _wait;

    private bool _isColorChanged = true;
    private MeshRenderer _meshRenderer;

    public static Action<Cube> ReturnPool;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        _meshRenderer.material.color = Color.white;
        _isColorChanged = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (_isColorChanged)
        {
            if (collider.TryGetComponent(out ReturnPool returnPool))
            {
                _isColorChanged = false;
                _meshRenderer.material.color = UnityEngine.Random.ColorHSV();
                _wait = new WaitForSeconds(UnityEngine.Random.Range(_minTimeDestroy, _maxTimeDestroy));
                StartCoroutine(DeletionDelay());
            }
        }
    }

    private IEnumerator DeletionDelay()
    {
        yield return _wait;
        ReturnPool?.Invoke(this);
    }
}
