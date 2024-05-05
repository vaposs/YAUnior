using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Cube _cube;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _efectPosition;
    [SerializeField] private int _maxPercent = 101;
    [SerializeField] private int _divisionСhance = 100;
    [SerializeField] private int _indexDivision = 2;
    [SerializeField] private int _countDevide;
    [SerializeField] private int _minDevide = 1;
    [SerializeField] private int _maxDevide = 7;
    [SerializeField] private float _tempScale;
    [SerializeField] private float _indexDivition = 0.5f;
    [SerializeField] private float _forse = 50;
    [SerializeField] private float _explosionRadiys = 2;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _particleSystem = GetComponentInChildren< ParticleSystem>();
        _meshRenderer.material.color = Random.ColorHSV();
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
            _explosionRadiys = _explosionRadiys / this.transform.localScale.x;
            _forse *= _explosionRadiys;
            _efectPosition = this.transform;
            Instantiate(_particleSystem, _efectPosition.position, Quaternion.identity).Play();
            Explosion();
        }

        Destroy(this.gameObject);
    }

    private void Explosion()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadiys);

        for (int i = 0; i <hits.Length; i++)
        {
            if (hits[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_forse, transform.position, _explosionRadiys);
            }
        }
    }

    private void NextLevelDivide()
    {
        _divisionСhance = _divisionСhance / _indexDivision;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _explosionRadiys);
    }
}
