using System;
using UnityEngine;

public class UploadingPlace : MonoBehaviour
{
    [SerializeField] private CommandCenter _commandCenter;

    public event Action PrintCountResource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DronLoadUnloadCargo dronLoadUnloadCargo))
        {
            if(dronLoadUnloadCargo.IsHaveResource)
            {
                PrintCountResource?.Invoke();
                dronLoadUnloadCargo.UnloadCargo();

                if (dronLoadUnloadCargo.TryGetComponent(out DronMover dronMover))
                {
                    _commandCenter.AddDron(dronMover);
                }
            }
        }
    }
}