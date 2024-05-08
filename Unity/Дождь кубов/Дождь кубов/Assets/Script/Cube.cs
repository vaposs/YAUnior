using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private bool _isChangeColor = true;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        _meshRenderer.material.color = Color.white;
        _isChangeColor = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<ReturnPool>(out ReturnPool returnPool))
        {
            if (_isChangeColor)
            {
                _isChangeColor = false;
                _meshRenderer.material.color = Random.ColorHSV();
            }
        }
    }
}
