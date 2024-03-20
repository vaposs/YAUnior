using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private PlayerMove _player;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _player.transform.position.x + _xOffset;
        transform.position = position;
    }
}