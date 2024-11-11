using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowCountResource : MonoBehaviour
{
    [SerializeField] private Text _resourceCount;

    public void Print(int countResorce)
    {
        _resourceCount.text = Convert.ToString(countResorce);
    }
}
