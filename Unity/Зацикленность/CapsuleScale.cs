using UnityEngine;

public class CapsuleScale : MonoBehaviour
{
    [SerializeField] private Transform _capsuleTransform;
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _growthRate;

    private void Update()
    {
        _capsuleTransform.localScale += new Vector3(_growthRate, _growthRate, _growthRate);

        if(_capsuleTransform.localScale.x > _maxScale)
        {
            _growthRate = _growthRate * -1;
        }
        else if(_capsuleTransform.localScale.x < _minScale)
        {
            _growthRate = _growthRate * -1;
        }
    }
}
