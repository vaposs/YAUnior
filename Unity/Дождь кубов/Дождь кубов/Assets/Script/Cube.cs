using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{

    private bool _changeColor = true;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

    }

    private void OnEnable()
    {
        _meshRenderer.material.color = Color.white;
        _changeColor = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<ReturnPool>(out ReturnPool returnPool))
        {
            if (_changeColor)
            {
                _changeColor = false;
                _meshRenderer.material.color = Random.ColorHSV();
            }
        }
    }
}
