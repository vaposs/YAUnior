using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public static event Action<Resource> Destroyed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DronMover dronMover))
        {
            if(transform.position == dronMover.TakeTargetPosition().position)
            {
                this.transform.SetParent(dronMover.transform);
                this.transform.position = dronMover.LoadCargo().localPosition;
            }
        }
    }
}