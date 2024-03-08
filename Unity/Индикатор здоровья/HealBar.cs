using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
    [SerializeField] private float _maxHeals;
    [SerializeField] private float _damage;
    [SerializeField] private float _healing;

    public float _heals;

    public event Action ChangeHeals;

    private void Start()
    {
        _heals = _maxHeals;
    }

    public void TakeDamage()
    {
        if ((_heals - _damage) <= 0)
        {
            _heals = 1;
        }
        else
        {
            _heals -= _damage;
        }

        ChangeHeals?.Invoke();
    }

    public void Healing()
    {
        if ((_heals + _healing) >= _maxHeals)
        {
            _heals = _maxHeals;
        }
        else
        {
            _heals += _healing;
        }

        ChangeHeals?.Invoke();
    }

    public float TakeHealCount()
    {
        return _maxHeals;
    }
}