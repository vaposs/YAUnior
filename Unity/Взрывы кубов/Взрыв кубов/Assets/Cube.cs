using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour, IPointerClickHandler
{
    private SpriteRenderer _spriteRenderer;
    private Cube _cube;
    private int _maxPercent = 101;
    private int _percentageDivide = 20;
    private int _nextPercentageDivide = 20;
    private int _countDevide;
    private int _minDevide = 1;
    private int _maxDevide = 7;
    private float _tempScale;
    private float _indexDivition = 0.5f;
    private Vector2 _vector;
    private float _forse = 50f;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Random.ColorHSV();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Random.Range(0, _maxPercent) > _percentageDivide)
        {
            _countDevide = Random.Range(_minDevide, _maxDevide);
            this.gameObject.SetActive(false);

            for (int i = 0; i < _countDevide; i++)
            {
                _cube = Instantiate(this);
                _tempScale = this.transform.localScale.x * _indexDivition;
                _cube.transform.localScale = new Vector3(_tempScale, _tempScale, _tempScale);
                _cube.transform.position = this.transform.position;
                _cube.NextLevelDivide(_nextPercentageDivide);
                _cube.gameObject.SetActive(true);
                AddForse(_cube);
            }
        }

        Destroy(this.gameObject);
    }

    private void AddForse(Cube cube)
    {
        _vector = new Vector2(Random.Range(-10,10), Random.Range(-10, 10));

        if (cube.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
        {
            rigidbody2D.AddForce(_vector * _forse);
        }
    }

    private void NextLevelDivide(int nextPercentageDivide)
    {
        _percentageDivide += nextPercentageDivide;
    }
}