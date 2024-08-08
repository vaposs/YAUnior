using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronLoadUnloadCargo : MonoBehaviour
{
    [SerializeField] private Transform _cargoTransform;

    private Resource _resource;

    public bool IsHaveCommand { get; private set; } = false;
    public bool IsHaveResource { get; private set; } = false;
    public Transform Target { get; private set; } = null;

    public void LoadCargo(Resource resource)
    {
        resource.transform.SetParent(this.transform);
        resource.transform.position = _cargoTransform.position;
        IsHaveResource = true;
        IsHaveCommand = false;
    }

    public void UnloadCargo()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent(out Resource resource))
            {
                _resource = resource;
            }
        }

        _resource.transform.parent = null;
        IsHaveResource = false;
        Target = null;
        _resource.DestroyResourse();
    }

    public void TakeCommand(Transform target)
    {
        Target = target;
        IsHaveCommand = true;
    }
}
