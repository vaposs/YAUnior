using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CommandCenter : MonoBehaviour
{
    [SerializeField] private DronMover[] _startDrons;
    [SerializeField] private Scaner _scaner;

    const KeyCode _scanKey = KeyCode.Q;

    private Queue<DronMover> _drons = new Queue<DronMover>();
    private Queue<Resource> _resource = new Queue<Resource>();
    private Transform _targetTransform;

    private void Awake()
    {
        for (int i = 0; i < _startDrons.Length; i++)
        {
            _drons.Enqueue(_startDrons[i]);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(_scanKey))
        {
            _resource = _scaner.Scan(_resource);
        }

        if (_drons.Count > 0)
        {
            _targetTransform = _resource.Count > 0 ? _resource.Dequeue().transform : null;

            if (_targetTransform != null)
            {
                SendDrone(_drons.Dequeue(), _targetTransform);
            }
        }
    }

    private void SendDrone(DronMover dron, Transform resource)
    {
        dron.TryGetComponent(out DronLoadUnloadCargo dronLoadUnloadCargo);
        dronLoadUnloadCargo.TakeCommand(resource.transform);
    }

    public void AddDron(DronMover dron)
    {
        _drons.Enqueue(dron);
    }
}