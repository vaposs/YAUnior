using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public event Action<Resource> Destroyed;

    public void ReturnInPool()
    {
        Destroyed?.Invoke(this);
    }
}