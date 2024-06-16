using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPlane : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private WaitForSeconds _wait;

    private void Start()
    {
        //_wait = new WaitForSeconds(_delay);
        //StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (enabled)
        {
            transform.RotateAround(_target.transform.position, Vector3.forward, _speed * Time.deltaTime);
            yield return _wait;
        }
    }
}
