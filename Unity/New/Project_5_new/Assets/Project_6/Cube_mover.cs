using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_mover : MonoBehaviour
{
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _growthRate;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speedMove;

    private void Start()
    {
        StartCoroutine(Scale());
        StartCoroutine(Rotation());
        StartCoroutine(Mover());
    }

    private IEnumerator Scale()
    {
        while(true)
        {
            transform.localScale += new Vector3(_growthRate, _growthRate, _growthRate);

            if (transform.localScale.x > _maxScale)
            {
                _growthRate = _growthRate * -1;
            }
            else if (transform.localScale.x < _minScale)
            {
                _growthRate = _growthRate * -1;
            }

            yield return null;
        }
    }

    private IEnumerator Rotation()
    {
        while(true)
        {
            transform.Rotate(transform.rotation.x, _speedRotation * Time.deltaTime, transform.rotation.z);

            yield return null;
        }
    }

    private IEnumerator Mover()
    {
        while(true)
        {
            transform.Translate(_speedMove,0,0);

            yield return null;
        }
    }
}
