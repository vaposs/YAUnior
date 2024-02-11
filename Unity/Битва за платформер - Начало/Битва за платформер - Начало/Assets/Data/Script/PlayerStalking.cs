using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(CharacterTracking))]

public class PlayerStalking: MonoBehaviour
{
    [SerializeField] private float _maxDistanse;
    [SerializeField] private Transform _transform;

    private RaycastHit2D _hit;
    private Vector2 _vector2;
    private EnemyMover _enemyMover;
    private CharacterTracking _characterTracking;
    private Vector3 rotate;

    private void Start()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _characterTracking = GetComponent<CharacterTracking>();
    }

    private void Update()
    {
        rotate = transform.eulerAngles;

        if (rotate.y == 0)
        {
            _vector2 = Vector2.left;
        }
        else
        {
            _vector2 = Vector2.right;
        }
        
        Debug.DrawRay(_transform.position, _vector2 * _maxDistanse);

        if (Physics2D.Raycast(_transform.position, _vector2, _maxDistanse))
        {
            _hit = Physics2D.Raycast(_transform.position, _vector2, _maxDistanse);

            if (_hit.collider.TryGetComponent(out PlayerMover playerMover))
            {
                _characterTracking.enabled = true;
                _enemyMover.enabled = false;
                this.enabled = false;
            }
        }
    }
}
