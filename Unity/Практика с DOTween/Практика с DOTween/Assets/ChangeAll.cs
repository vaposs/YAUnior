using DG.Tweening;
using UnityEngine;

public class ChangeAll : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _duration;

    private Vector3 _rotation = new Vector3(0, 180, 0);
    private Vector3 _scale = new Vector3(3, 3, 3);
    private int _repeats = -1;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(_target.position, _duration));
        sequence.SetLoops(_repeats, LoopType.Yoyo);
        sequence.SetEase(Ease.Linear);
        sequence.Insert(0f, transform.DOLocalRotate(_rotation, _duration));
        sequence.SetLoops(_repeats, LoopType.Yoyo);
        sequence.SetEase(Ease.Linear);
        sequence.Insert(0f, transform.DOScale(_scale, _duration));
        sequence.SetLoops(_repeats, LoopType.Yoyo);
        sequence.SetEase(Ease.Linear);
    }
}
