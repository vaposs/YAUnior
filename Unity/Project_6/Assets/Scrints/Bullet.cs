using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    public int Damage { get; internal set; }

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
