using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _indexRotation = 0.5f;
    [SerializeField] private float _angleMin = -90;
    [SerializeField] private float _angleMax = 0;



    private void Update()
    {
        RotationGun();
    }

    private void RotationGun()
    {
        _transform.Rotate(0,0,_indexRotation);

        var angle = transform.eulerAngles.z;
        angle = Mathf.Repeat(angle + 180, 360) - 180;

        if (angle < _angleMin)
        {
            _indexRotation = _indexRotation * -1;
        }
        else if (angle > _angleMax)
        {
            _indexRotation = _indexRotation * -1;
        }
    }
}