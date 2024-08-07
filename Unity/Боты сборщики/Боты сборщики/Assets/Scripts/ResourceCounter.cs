using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private Text _resourceCount;
    [SerializeField] private UploadingPlace _uploadingPlace;

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
        _resourceCount.text = Convert.ToString(_countResorce);
    }
}
