using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitterExplosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private KeyCode _tapKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(_tapKey))
        {
            PlayEffect();
        }
    }

    private void PlayEffect()
    {
        _effect.Play();
    }
}
