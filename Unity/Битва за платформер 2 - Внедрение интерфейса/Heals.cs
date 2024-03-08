using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heals : MonoBehaviour
{
    private int _healSize = 20;
    private int _speedRotation = 3;
    private PlayerMover _playerMover;

    private void Update()
    {
        transform.Rotate(0, _speedRotation, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.TryGetComponent<PlayerMover>(out _playerMover))
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
