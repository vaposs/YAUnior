using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CommandCenter : MonoBehaviour
{
    [SerializeField] private ResourcePool _resourcePool;
    [SerializeField] private Queue<DronMover> _drons;

    private Transform _targetTransform;

    private void Awake()
    {
        _drons = new Queue<DronMover>();
        DronMover[] drons = FindObjectsOfType<DronMover>();

        foreach (DronMover dron in drons)
        {
            _drons.Enqueue(dron);
        }
    }

    private void Update()
    {
        if(_drons.Count > 0)
        {
            _targetTransform = _resourcePool.GetPosition();

            if(_targetTransform != null)
            {
                SendDrone(_drons.Dequeue(), _targetTransform);
            }
        }
    }

    private void SendDrone(DronMover dron, Transform resource)
    {
        dron.TakeCommand(resource.transform);
    }

    public void AddDron(DronMover dron)
    {
        _drons.Enqueue(dron);
    }
}
