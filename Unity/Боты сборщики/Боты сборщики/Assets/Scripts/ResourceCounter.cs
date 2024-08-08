using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private UploadingPlace _uploadingPlace;
    [SerializeField] private ShowCountResource _showCountResource;

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
        _showCountResource.Print(_countResorce);
    }
}
