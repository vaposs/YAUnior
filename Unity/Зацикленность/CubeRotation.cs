using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private Transform _cubeTransform;
    [SerializeField] private float _speedRotation;

    private void Update()
    {
        _cubeTransform.Rotate(_cubeTransform.rotation.x, _speedRotation * Time.deltaTime, _cubeTransform.rotation.z);
    }
}
