using UnityEngine;
using UnityEngine.EventSystems;

public class CubeTwoPointZero : MonoBehaviour, IPointerClickHandler
{
    private SpriteRenderer _spriteRenderer;
    private CubeTwoPointZero _cube;
    private int _maxPercent = 101;
    private int _divisionСhance = 100;
    private int _indexDivision = 2;
    private int _countDevide;
    private int _minDevide = 1;
    private int _maxDevide = 7;
    private float _tempScale;
    private float _indexDivition = 0.5f;
    private Vector2 _vector;
    private float _forse = 10f;
    private float _minVectorRange = -10;
    private float _maxVectorRange = 10;
    private float _explosionRadiys = 10f;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Random.ColorHSV();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Random.Range(0, _maxPercent) < _divisionСhance)
        {
            _countDevide = Random.Range(_minDevide, _maxDevide);
            this.gameObject.SetActive(false);

            for (int i = 0; i < _countDevide; i++)
            {
                _cube = Instantiate(this);
                _tempScale = this.transform.localScale.x * _indexDivition;
                _cube.transform.localScale = new Vector3(_tempScale, _tempScale, _tempScale);
                _cube.transform.position = this.transform.position;
                _cube.NextLevelDivide();
                _cube.gameObject.SetActive(true);
            }
        }
        else
        {
            _explosionRadiys = _explosionRadiys - this.transform.localScale.x;
            _forse =  _explosionRadiys;
            Explosion();
        }

        Destroy(this.gameObject);
    }

    private void Explosion()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _explosionRadiys);

        foreach (var hit in hits)
        {
            _vector = new Vector2(Random.Range(_minVectorRange, _maxVectorRange), Random.Range(_minVectorRange, _maxVectorRange));

            if (hit.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
            {
                rigidbody2D.AddForce(_vector * _forse);
            }
        }
    }

    private void NextLevelDivide()
    {
        _divisionСhance = _divisionСhance / _indexDivision;
    }
}