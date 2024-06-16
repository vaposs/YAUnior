using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenter : MonoBehaviour
{
    [SerializeField] private ResourcePool _resourcePool;

    private Queue<DronMover> _drons;

    private void Awake()
    {
        _drons = new Queue<DronMover>();
    }

    private void Update()
    {
        if(_drons.Count > 0)
        {
            if(_resourcePool.CheckCounPool() > 0)
            {
                SendDrone(_drons.Dequeue(), _resourcePool.GetPosition());
            }
        }
    }

    private void SendDrone(DronMover dron, Resource resource)
    {
        dron.TakeCommand(resource.transform);
    }

    public void AddDron(DronMover dron)
    {
        _drons.Enqueue(dron);
    }
}
