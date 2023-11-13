using System;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private bool _stayCollider = false;
    private bool _exitCollider = false;
    private float _startVolume = 0.01f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
                _audioSource.volume = _startVolume;
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _stayCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _exitCollider = true;
            _stayCollider = false;
        }
    }

    private void Update()
    {
        if(_stayCollider == true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, 0.1f * Time.deltaTime);
        }

        if(_exitCollider == true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, (0.1f * Time.deltaTime) * -1);            Debug.Log("вышли за границы тригера/громкость вниз - " + _audioSource.volume);
        }

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
            _stayCollider = false;
            _exitCollider = false;
        }
    }
}