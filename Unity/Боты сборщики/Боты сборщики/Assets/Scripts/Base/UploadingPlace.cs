using System;
using UnityEngine;

public class UploadingPlace : MonoBehaviour
{
    [SerializeField] private CommandCenter _commandCenter;

    public event Action PrintCountResource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DronMover dronMover))
        {
            if(dronMover.IsHaveResourse())
            {
                PrintCountResource?.Invoke();
                dronMover.UnloadCargo();
                _commandCenter.AddDron(dronMover);
            }
        }
    }
}
