using UnityEngine;

public class TurnMusic : MonoBehaviour
{
    private const string Player = nameof(Player);

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Signal _signal;
    private float _minVolume = 0f;
    private float _startVolume = 0.1f;
    private float _maxVolume = 1f;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Player)
        {
            if (_audioSource.isPlaying == false)
            {
                Debug.Log("старт");
                _audioSource.Play();
                _audioSource.volume = _startVolume;
                _signal.ChangeVolume(_maxVolume);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("стоп");
        _signal.ChangeVolume(_minVolume);
    }
}