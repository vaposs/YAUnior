using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Text _text;
    [SerializeField] private KeyCode _keyCommand = KeyCode.Mouse0;

    private int _numberText = 0;
    private Coroutine _coroutine = null;

    private void Update()
    {
        if(Input.GetKeyDown(_keyCommand))
        {
            if(_coroutine == null)
            {
                _coroutine = StartCoroutine(Scored(_delay));
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator Scored(float delay)
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
