using System;
using UnityEngine;

public class HealsBar : MonoBehaviour
{
    [SerializeField] private int _maxHeals = 100;

    public int _heals;
    public event Action ChangeHeals;

    private void Start()
    {
        _heals = _maxHeals;
    }

    public void TakeHeals(int heals)
    {
        _heals += heals;

        if (_heals > _maxHeals)
        {
            _heals = _maxHeals;
        }

        ChangeHeals?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _heals -= damage;

        if (_heals <= 0)
        {
            Destroy(gameObject);
        }

        ChangeHeals?.Invoke();
    }

    public float TakeHealCount()
    {
        return _maxHeals;
    }

    public int TakeHealCurrent()
    {
        return _heals;
    }
}
