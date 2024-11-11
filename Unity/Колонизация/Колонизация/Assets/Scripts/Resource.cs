using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public event Action<Resource> Destroyed;

    public void DestroyResourse()
    {
        Destroyed?.Invoke(this);
    }
}