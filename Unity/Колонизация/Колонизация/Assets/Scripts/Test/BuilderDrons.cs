using UnityEngine;

public class BuilderDrons : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private MeshRenderer _meshRenderer;

    private Color _nativeColor;

    private void Start()
    {
        _nativeColor = _meshRenderer.material.color;
    }

    public void SelectColor()
    {
        _meshRenderer.material.color = _color;
    }

    public void UnselectBase()
    {
        _meshRenderer.material.color = _nativeColor;
    }
}
