using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private Slider _sliderVolumeAllMusic;
    [SerializeField] private Slider _sliderVolumeFonMusic;
    [SerializeField] private Slider _sliderVolumeButtonMusic;
    [SerializeField] private AudioMixer _audioMixer;

    public event Action ChangeVolume;

    private int _maxVolumeMusic = 100;
    private int _middleVolumeMusic = 50;

    private void Start()
    {
        _sliderVolumeAllMusic.maxValue = _maxVolumeMusic;
        _sliderVolumeFonMusic.maxValue = _maxVolumeMusic;
        _sliderVolumeButtonMusic.maxValue = _maxVolumeMusic;
    }

    public void VolumeAll()
    {

    }

    public void Button(string name)
    {
        PlayClicButton(Convert.ToInt16(name));
    }

    public void OffOnMusic()
    {
        _audioMixer.SetFloat("Master", 0);
    }

    private void PlayClicButton(int index)
    {
       // _audioSourceButton.clip = _audioClips[index - 1];
       // _audioSourceButton.Play();
    }
}
