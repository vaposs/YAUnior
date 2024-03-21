using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Text _text;
    [SerializeField] private KeyCode _keyCommandStart = KeyCode.Mouse0;
    [SerializeField] private KeyCode _keyCommandStop = KeyCode.Mouse1;

    private int _numberText = 0;
    private bool _isWorcCoroutine = false;

    private void Update()
    {
        if(Input.GetKeyDown(_keyCommandStart))
        {
            if(_isWorcCoroutine == false)
            {
                _isWorcCoroutine = true;
                StartCoroutine(Scored(_delay));
            }
        }

        if (Input.GetKeyDown(_keyCommandStop))
        {
            if (_isWorcCoroutine == true)
            {
                _isWorcCoroutine = false;
                StopAllCoroutines();
            }
        }
    }

    IEnumerator Scored(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            _numberText++;
            _text.text = Convert.ToString(_numberText);
            yield return wait;
        }
    }
}
