using UnityEngine;

public class Cube_rotation : MonoBehaviour
{
    [SerializeField] private float _speedRotation;

    void Update()
    {
        transform.Rotate(transform.rotation.x, _speedRotation * Time.deltaTime, transform.rotation.z);
    }
}
