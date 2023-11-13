using System;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    private bool _stayCollider = false;
    private bool _exitCollider = false;
    private float _startVolume = 0.01f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (AudioSource.isPlaying == false)
            {
                AudioSource.Play();
                AudioSource.volume = _startVolume;
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
            AudioSource.volume = Mathf.MoveTowards(AudioSource.volume, 1, 0.1f * Time.deltaTime);
        }

        if(_exitCollider == true)
        {
            AudioSource.volume = Mathf.MoveTowards(AudioSource.volume, 1, (0.1f * Time.deltaTime) * -1);            Debug.Log("вышли за границы тригера/громкость вниз - " + AudioSource.volume);
        }

        if (AudioSource.volume == 0)
        {
            AudioSource.Stop();
            _stayCollider = false;
            _exitCollider = false;
        }
    }
}