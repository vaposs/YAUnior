using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private AudioSource _audioSource;

    private KeyCode _shootChar = KeyCode.C;

    private void Update()
    {
        if(Time.timeScale > 0)
        {
            if (Input.GetKeyDown(_shootChar))
            {
                _bulletPool.GetObject();
                _audioSource.Play();
            }
        }
    }
}