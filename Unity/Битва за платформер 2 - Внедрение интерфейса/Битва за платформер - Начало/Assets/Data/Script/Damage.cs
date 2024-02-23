using System;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private HealsBar _healsBar;
    [SerializeField] private int _damage = 50;

    private string _nameTriger = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.transform.tag == _nameTriger)
            {
                _healsBar.TakeDamage(_damage);
            }
        }
    }
}