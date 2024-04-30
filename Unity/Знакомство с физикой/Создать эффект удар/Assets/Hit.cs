using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Hit: MonoBehaviour
{
    [SerializeField] private ParticleSystem _hit;
    [SerializeField] private Transform _checkCirclePoint;
    [SerializeField] private float _searchDistanse;
    
    private Animator _animatorPlayer;
    private KeyCode _keyAttack = KeyCode.Space;
    private string _attack = "Hit";

    private void Start()
    {
        _animatorPlayer = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyAttack))
        {
            _animatorPlayer.SetTrigger(_attack);
            CheckEnemy();
        }
        else
        {
            _animatorPlayer.SetBool(_attack, false);
        }
    }

    private void CheckEnemy()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(_checkCirclePoint.position, _searchDistanse);

        foreach (var enemy in targets)
        {
            if(enemy.TryGetComponent<Enemy>(out Enemy en))
            {
                _hit.transform.LookAt(_checkCirclePoint);
                _hit.Play();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_checkCirclePoint.position, _searchDistanse);
    }
}
