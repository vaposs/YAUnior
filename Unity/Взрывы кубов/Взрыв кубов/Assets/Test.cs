using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Vector2 Vector2 = new Vector2(0,10);
    [SerializeField] private int _forse;

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
