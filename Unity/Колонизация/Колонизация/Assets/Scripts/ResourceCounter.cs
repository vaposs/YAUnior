using UnityEngine;

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

    public int ChacCountResoirse()
    {
        return _countResorce;
    }

    public void BuyBase(int costBase)
    {
        _countResorce -= costBase;
        _showCountResource.Print(_countResorce);
    }
}