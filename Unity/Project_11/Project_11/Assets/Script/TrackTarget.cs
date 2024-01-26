using UnityEngine;

public class TrackTarget : MonoBehaviour
{
    [SerializeField] private Transform _tower;
    [SerializeField] private Transform _target;

    private void Update()
    {
        _tower.transform.LookAt(_target);
    }

    public Transform TakePositionTarget()
    {
        return _target;
    }
}