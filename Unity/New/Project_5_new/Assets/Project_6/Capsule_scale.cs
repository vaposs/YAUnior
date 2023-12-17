using UnityEngine;

public class Capsule_scale : MonoBehaviour
{
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _growthRate;

    void Update()
    {
        transform.localScale += new Vector3(_growthRate, _growthRate, _growthRate);

        if(transform.localScale.x > _maxScale)
        {
            _growthRate = _growthRate * -1;
        }
        else if(transform.localScale.x < _minScale)
        {
            _growthRate = _growthRate * -1;
        }
    }
}
