using UnityEngine;
using UnityEngine.UI;

public class DrawHealbarNumber : MonoBehaviour
{
    [SerializeField] private Text _maxHealsText;
    [SerializeField] private Text _healsText;
    [SerializeField] private Text _separatorText;
    [SerializeField] private char _separatorHpBar;
    [SerializeField] private HealBar _healBar;

    private float _maxHeals;

    private void Start()
    {
        float heals = _healBar.TakeHealCount();
        _maxHeals = heals;
        _maxHealsText.text = _maxHeals.ToString();
        _separatorText.text = _separatorHpBar.ToString();
    }

    private void OnEnable()
    {
        _healBar.ChangeHeals += DrawHealbar;
    }

    private void OnDisable()
    {
        _healBar.ChangeHeals -= DrawHealbar;
    }

    public void DrawHealbar()
    {
        _healsText.text = _healBar._heals.ToString();
    }
}
