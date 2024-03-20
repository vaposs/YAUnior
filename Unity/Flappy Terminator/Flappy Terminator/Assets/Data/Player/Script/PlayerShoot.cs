using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private AudioSource _audioSource;

    private void Update()
    {
        if(Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                _bulletPool.GetObject();
                _audioSource.Play();
            }
        }
    }
}