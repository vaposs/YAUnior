using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeals : MonoBehaviour
{
    [SerializeField] private int _heals = 100;

    public event Action ChangeEnemyHeals;

    private void TakeDamage(int damage)
    {
        _heals -= damage;

        if (_heals <= 0)
        {
            Destroy(gameObject);
        }

        ChangeEnemyHeals?.Invoke();
    }
}
