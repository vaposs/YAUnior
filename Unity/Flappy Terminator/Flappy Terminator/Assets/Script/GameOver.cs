using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private PlayerMover _playerMover;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<PlayerMover>(out _playerMover))
        {
            _mainMenu.GameOver();
            Destroy(_playerMover.gameObject);
        }
    }
}