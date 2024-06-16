using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private Text _resourceCount;
    [SerializeField] private int _costDrone;
    [SerializeField] private UploadingPlace _uploadingPlace;

    public event Action SpawnDron;

    private int _countResorce = 0;

    private void OnEnable()
    {
        _uploadingPlace.PrintCountResource += AddCountResource;
    }

    private void OnDisable()
    {
        _uploadingPlace.PrintCountResource -= AddCountResource;
    }

    private void AddCountResource()
    {
        _countResorce++;

        if (_countResorce >= _costDrone)
        {
            SpawnDron?.Invoke();
            _countResorce -= _costDrone;
        }

        _resourceCount.text = Convert.ToString(_countResorce);

    }
}
