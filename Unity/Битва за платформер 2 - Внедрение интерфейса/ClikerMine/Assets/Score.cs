using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Clik _clik;

    private void OnEnable()
    {
        _clik.ChangeScore += DrawHealbar;
    }

    private void OnDisable()
    {
        _clik.ChangeScore -= DrawHealbar;
    }

    public void DrawHealbar()
    {
        _scoreText.text = _clik._score.ToString();
    }
}
