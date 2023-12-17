using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private float _speedRotation;

    private void Update()
    {
        transform.Rotate(transform.rotation.x, _speedRotation * Time.deltaTime, transform.rotation.z);
    }
}
