using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    [SerializeField] private float _scanRadius;

    private float _pointRadius = 5;
    private LayerMask _mask = 9;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(transform.position, _pointRadius);
        Gizmos.DrawWireSphere(transform.position, _scanRadius);
    }

    public Queue<Resource> Scan(Queue <Resource> _resource)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _scanRadius, _mask);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].TryGetComponent(out Resource resource))
            {
                if (!_resource.Contains(resource))
                {
                    _resource.Enqueue(resource);
                }
            }
        }

        return _resource;
    }
}
