using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawHealbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private HealsBar _healsBar;
    [SerializeField] private Image _colorImage;

    private float _recoveryRate = 0.1f;
    private Color _colorHide = Color.green;
    private Color _colorMedium = Color.yellow;
    private Color _colorLow = Color.red;
    private int _colorHideCount = 50;
    private int _colorMediumCount = 25;

    private void Start()
    {
        _slider.minValue = 1;
        _slider.maxValue = _healsBar.TakeHealCount();
        _slider.value = _healsBar.TakeHealCount();
        _colorImage.color = _colorHide;
    }

    private void OnEnable()
    {
        _healsBar.ChangeHeals += DrawHealbars;
    }

    private void OnDisable()
    {
        _healsBar.ChangeHeals -= DrawHealbars;
    }

    private void DrawHealbars()
    {
        if (ChangeValueSlider(_healsBar._heals) != null)
        {
            StopAllCoroutines();
        }

        if (_slider.value != _healsBar._heals)
        {
            StartCoroutine(ChangeValueSlider(_healsBar._heals));
        }
    }

    private IEnumerator ChangeValueSlider(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            ColorBar();
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _recoveryRate);

            yield return null;
        }
    }

    private void ColorBar()
    {
        if (_slider.value > 50)
        {
            _colorImage.color = _colorHide;
        }
        else if (_slider.value > _colorMediumCount && _slider.value <= _colorHideCount)
        {
            _colorImage.color = _colorMedium;
        }
        else if (_slider.value <= _colorMediumCount)
        {
            _colorImage.color = _colorLow;
        }
    }
}