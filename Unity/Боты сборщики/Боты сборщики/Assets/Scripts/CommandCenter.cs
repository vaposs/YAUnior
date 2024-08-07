using System.Collections.Generic;
using UnityEngine;

public class CommandCenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _scanRadius;
    [SerializeField] private Transform asd;
    [SerializeField] private Queue<DronMover> _drons;

    private float _pointRadius = 5;
    private int _lengRay = 500;
    private RaycastHit _hit;
    private Ray _ray;
    private Queue<Resource> _resursers = new Queue<Resource>();
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
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(_ray.origin, _ray.direction * _lengRay, Color.red);

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.transform.GetComponent<Ground>())
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Collider[] hits = Physics.OverlapSphere(_hit.point, _scanRadius);

                    Scan(hits);
                }
            }
        }

        if (_drons.Count > 0)
        {
            _targetTransform = _resursers.Count > 0 ? _resursers.Dequeue().transform : null;

            if (_targetTransform != null)
            {
                SendDrone(_drons.Dequeue(), _targetTransform);
            }
        }
    }

    private void Scan(Collider[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].TryGetComponent<Resource>(out Resource resource))
            {
                if(!_resursers.Contains(resource))
                {
                    _resursers.Enqueue(resource);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
        {
            Gizmos.DrawSphere(_hit.point, _pointRadius);
            Gizmos.DrawWireSphere(_hit.point, _scanRadius);
        }
    }

    private void SendDrone(DronMover dron, Transform resource)
    {
        dron.GetCommand(resource.transform);
    }

    public void AddDron(DronMover dron)
    {
        _drons.Enqueue(dron);
    }
}