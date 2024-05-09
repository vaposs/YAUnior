using DG.Tweening;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        transform.DOMove(_target.position, _duration).SetLoops(_repeats, _loopType);
    }
}
