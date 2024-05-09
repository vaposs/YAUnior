using UnityEngine;
using DG.Tweening;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _vector3;

    private int _repeats = -1;

    private void Start()
    {
        transform.DOLocalRotate(_vector3, _duration)
            .SetLoops(_repeats, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }
}
