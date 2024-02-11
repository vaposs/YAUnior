using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHeals : MonoBehaviour
{
    private string _nameTriger = "Player";
    private int _healSize = 20;
    private int _speedRotation = 3;

    void Update()
    {
        transform.Rotate(0, _speedRotation, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.transform.tag == _nameTriger)
            {
                Destroy(gameObject);
            }
        }
    }

    public int MakeHeals()
    {
        return _healSize;
    }
}
