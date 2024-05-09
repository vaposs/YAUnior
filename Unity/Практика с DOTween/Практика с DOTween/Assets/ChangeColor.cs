using DG.Tweening;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Color _firstColor;
    [SerializeField] private Color _secondColor;
    [SerializeField] private float _duration;
    [SerializeField] private MeshRenderer _meshRenderer;

    private int _repeats = -1;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_meshRenderer.material.DOColor(_firstColor, _duration));
        sequence.Insert(2f, _meshRenderer.material.DOColor(_secondColor, _duration));
        sequence.SetLoops(_repeats, LoopType.Restart);
        //sequence.SetEase(Ease.Linear);
    }
}
