using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _slider;

    private float _startVolumeMusic = 0.5f;

    private void Start()
    {
        _slider.value = _startVolumeMusic;
    }

    private void Update()
    {
        _audioSource.volume = _slider.value;
    }
}
