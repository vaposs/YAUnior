using DG.Tweening;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _vector3;

    private int _repeats = -1;

    private void Start()
    {
        transform.DOScale(_vector3, _duration)
            .SetLoops(_repeats, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}
