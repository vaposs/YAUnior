using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clik : MonoBehaviour
{
    private int _coefficient = 1;

    public int _score = 0;
    public event Action ChangeScore;

    public void Cliks()
    {
        _score = _score + _coefficient;

        ChangeScore?.Invoke();
    }

    private void CoefficientUp(int count)
    {
        _coefficient = _coefficient + count;
    }
}
