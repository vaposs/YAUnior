using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundAirplane : MonoBehaviour
{
    [SerializeField] private AudioSource _engineSoung;
    [SerializeField] private AudioSource _shootingSoung;
    [SerializeField] private Slider _slider;

    private float _startVolumeAirPlane = 1f;

    private void Start()
    {
        _slider.value = _startVolumeAirPlane;
    }

    private void Update()
    {
        _engineSoung.volume = _slider.value;
        _shootingSoung.volume = _slider.value;
    }
}
