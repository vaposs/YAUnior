using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private int _timeToDie;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        Destroy(gameObject, _timeToDie);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _animator.SetTrigger("Dead");
            Destroy(this.gameObject,1);
        }
    }
}
