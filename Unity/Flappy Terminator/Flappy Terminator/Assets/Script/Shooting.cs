using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private AudioSource _audioSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(_bullet, _spawnPosition.transform.position, Quaternion.identity);
            _audioSource.Play();
        }
    }
}