using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _minTimeDestroy = 2;
    [SerializeField] private float _maxTimeDestroy = 6;

    private WaitForSeconds _wait;

    private bool _iseColorChanged = true;
    private MeshRenderer _meshRenderer;

    public static Action<Cube> onToched;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        _meshRenderer.material.color = Color.white;
        _iseColorChanged = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (_iseColorChanged)
        {
            if (collider.TryGetComponent<ReturnPool>(out ReturnPool returnPool))
            {
                _iseColorChanged = false;
                _meshRenderer.material.color = UnityEngine.Random.ColorHSV();
                _wait = new WaitForSeconds(UnityEngine.Random.Range(_minTimeDestroy, _maxTimeDestroy));
                StartCoroutine(DeletionDelay());
            }
        }
    }

    private IEnumerator DeletionDelay()
    {
        yield return _wait;
        onToched?.Invoke(this);
    }
}
