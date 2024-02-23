using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWorld : MonoBehaviour
{
    [SerializeField] private HealsBar _healsBar;
    [SerializeField] private PlayerMover _playerMover;

    private PlayerStalking _playerStalking;
    private Heals _takeHeals;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Heals>(out _takeHeals))
        {
            _healsBar.TakeHeals(_takeHeals.MakeHeals());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerStalking>(out _playerStalking))
        {
            _healsBar.TakeDamage(_playerStalking.MakeDamage());
            _playerMover.AddForse();
        }
    }
}