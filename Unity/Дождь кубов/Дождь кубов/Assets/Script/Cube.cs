using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _minTimeDestroy = 2;
    [SerializeField] private float _maxTimeDestroy = 5;

    private bool _changeColor = true;
    private MeshRenderer _meshRenderer;
    private float _timeDestroy;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter()
    {
        if(_changeColor)
        {
            _changeColor = false;
            _meshRenderer.material.color = Random.ColorHSV();
            _timeDestroy = Random.Range(_minTimeDestroy, _maxTimeDestroy);
            Destroy(gameObject, _timeDestroy);
        }
    }
}
