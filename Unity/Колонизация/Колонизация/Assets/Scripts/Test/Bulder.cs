using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulder : MonoBehaviour
{
    private Vector3 _target = Vector3.zero;
    private float _speed = 100;
    private ChooseBase _newBase;

    private void Update()
    {
        if (_target != Vector3.zero)
        {
            MoveToTarget(_target);

            if (transform.position == _target)
            {
                Instantiate(_newBase, _target, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        transform.LookAt(target);
    }

    public void TakeTarget(Vector3 target)
    {
        _target = target;
    }

    public void TakePrefabBase(ChooseBase newBase)
    {
        _newBase = newBase;
    }
}
