using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;

    private bool _isActive = true;

    public void OpenClouseShop()
    {
        if(_isActive)
        {
            _shopPanel.SetActive(false);
            _isActive = false;
        }
        else
        {
            _shopPanel.SetActive(true);
            _isActive = true;
        }
    }
}
