using UnityEngine;
using UnityEngine.UI;

public class BulderNewBase : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _nameText2; // test
    [SerializeField] private Camera _camera;
    [SerializeField] private KeyCode _keyCodeSelect;
    [SerializeField] private KeyCode _keyCodeBuild;
    [SerializeField] private ChooseBase _prefabNewBase;
    [SerializeField] private Bulder _prefabBulder;
    [SerializeField] private int _costNewBase;

    private Ray _ray;
    private RaycastHit _raycastHit;
    private BuilderDrons _selectBases;
    private BuilderDrons _previosBase = null;
    private bool _isSelectedBase = false;
    private Bulder _temBulderNewBase;
    private ResourceCounter _resourceCounter;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_ray, out _raycastHit);

        if (Input.GetKeyDown(_keyCodeSelect))
        {
            SelectBase();
        }

        if (Input.GetKeyDown(_keyCodeBuild) && _isSelectedBase == true)
        {
            BuldBase(_raycastHit.point);
        }

        Debug.DrawRay(_ray.origin, _ray.direction * 1000);
    }

    private void SelectBase()
    {
        _nameText2.text = _raycastHit.transform.name;

        if (_raycastHit.transform.TryGetComponent(out _selectBases))
        {
            _nameText.text = _raycastHit.transform.name;

            if (_previosBase != _selectBases)
            {
                if(_previosBase != null)
                {
                    _previosBase.UnselectBase();
                }
                    
                _previosBase = _selectBases;
                _selectBases.SelectColor();
                _isSelectedBase = true;
            }
            else
            {
                _previosBase.UnselectBase();
                _isSelectedBase = false;
                _previosBase = null;
            }
        }
        else
        {
            _nameText.text = "null";
        }
    }

    private void BuldBase(Vector3 target)
    {
        if (_selectBases.transform.GetChild(2).TryGetComponent<ResourceCounter>(out _resourceCounter))
        {
            if (_resourceCounter.ChacCountResoirse() >= _costNewBase)
            {
                _resourceCounter.BuyBase(_costNewBase);

                _temBulderNewBase = Instantiate(_prefabBulder, _selectBases.transform.position, Quaternion.identity);
                _temBulderNewBase.TakePrefabBase(_prefabNewBase);
                _temBulderNewBase.TakeTarget(new Vector3(target.x, 0, target.z));
            }
        }
    }
}
