using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Gem : MonoBehaviour
{
    private const string Player = nameof(Player);
    private const string Dead = nameof(Dead);

    [SerializeField] private int _timeToDie;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        Destroy(gameObject, _timeToDie);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Player)
        {
            _animator.SetTrigger(Dead);
            Destroy(this.gameObject,1);
        }
    }
}
