using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawHealbarSlow : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private HealBar _healBar;
    [SerializeField] private Image _colorImage;

    private float _recoveryRate = 0.1f;
    private Color _colorHide = Color.green;
    private Color _colorMedium = Color.yellow;
    private Color _colorLow = Color.red;
    private int _colorHideCount = 50;
    private int _colorMediumCount = 25;

    private void Start()
    {
        float maxHeals = _healBar.TakeHealCount();
        _slider.minValue = 1;
        _slider.maxValue = maxHeals;
        _slider.value = maxHeals;
        _colorImage.color = _colorHide;
    }

    private void OnEnable()
    {
        _healBar.ChangeHeals += DrawHealbar;
    }

    private void OnDisable()
    {
        _healBar.ChangeHeals -= DrawHealbar;
    }

    private void DrawHealbar()
    {
        if(ChangeValueSlider(_healBar._heals) != null)
        {
            StopAllCoroutines();
        }

        if (_slider.value != _healBar._heals)
        {
            StartCoroutine(ChangeValueSlider(_healBar._heals));
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
