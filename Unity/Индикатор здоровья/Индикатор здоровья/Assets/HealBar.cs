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
    [SerializeField] private Text _maxHealsText;
    [SerializeField] private Text _healsText;
    [SerializeField] private Text _separatorText;
    [SerializeField] private char _separatorHpBar;
    [SerializeField] private Slider _slider_1;
    [SerializeField] private Slider _slider_2;

    private float _heals;
    private float _targetValue;
    private float recoveryRate = 0.1f;

    private void Start()
    {
        _heals = _maxHeals;
        _maxHealsText.text = _maxHeals.ToString();
        _separatorText.text = _separatorHpBar.ToString();
        _slider_1.minValue = 1;
        _slider_1.maxValue = _maxHeals;
        _slider_1.value = _heals;
        _slider_2.minValue = 1;
        _slider_2.maxValue = _maxHeals;
        _slider_2.value = _heals;
    }

    private void Update()
    {
        _healsText.text = _heals.ToString();
        _slider_1.value = _heals;

        if(_slider_2.value != _heals)
        {
            _slider_2.value = Mathf.MoveTowards(_slider_2.value, _targetValue, recoveryRate);
        }
    }

    public void TakeDamage()
    {
        _targetValue = _heals - _damage;

        if ((_heals - _damage) <= 0)
        {
            _heals = 1;
            _targetValue = 1;
        }
        else
        {
            _heals -= _damage;
        }
    }

    public void Healing()
    {
        _targetValue = _heals + _healing;

        if ((_heals + _healing) >= _maxHeals)
        {
            _heals = _maxHeals;
            _targetValue = _maxHeals;
        }
        else
        {
            _heals += _healing;
        }
    }
}
