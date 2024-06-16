using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private DronMover _drone;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Transform _pool;
    [SerializeField] private CommandCenter _commandCenter;
    [SerializeField] private Transform _uploadingPlace;
    [SerializeField] private ResourceCounter _resourceCounter;

    private DronMover _tempDron;

    private void OnEnable()
    {
        _resourceCounter.SpawnDron += Spawn;
    }

    private void OnDisable()
    {
       _resourceCounter.SpawnDron -= Spawn;
    }

    public void Spawn()
    {
        _tempDron = Instantiate(_drone, new Vector3(_spawn.position.x, _spawn.position.y, _spawn.position.z), _spawn.rotation, _pool);
        _tempDron.TakeWaypoints(_movePoints);
        _tempDron.TakeCommandCentrePosition(_uploadingPlace);
        _commandCenter.AddDron(_tempDron);
    }
}
