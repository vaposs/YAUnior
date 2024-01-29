using System.Collections;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _stepChangeVolume = 0.1f;
    private bool _workCoroutine = false;

    public void ChangeVolume(float targetVolume)
    {
        if(_workCoroutine == false)
        {
            StartCoroutine(VolumeUpOrDawn(targetVolume));
            _workCoroutine = true;
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(VolumeUpOrDawn(targetVolume));
        }
    }

    private IEnumerator VolumeUpOrDawn(float targetVolume)
    {
        while(_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _stepChangeVolume * Time.deltaTime);

            yield return null;
        }

        if(_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }
}