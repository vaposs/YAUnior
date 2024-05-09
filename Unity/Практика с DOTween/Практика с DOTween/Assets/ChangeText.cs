using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _changeText;
    [SerializeField] private string _addText;
    [SerializeField] private string _efectChangeText;
    [SerializeField] private float _duration;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_text.DOText(_changeText, _duration));
        sequence.Insert(_duration,_text.DOText(_addText, _duration).SetRelative());
        sequence.Insert(_duration*2, _text.DOText(_efectChangeText, _duration, true, ScrambleMode.All));
        sequence.SetEase(Ease.Linear);
    }
}