using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public static event Action<Resource> Destroyed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<DronMover>(out DronMover dronMover))
        {
            dronMover.LoadCargo();
            Destroyed?.Invoke(this);
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }
}