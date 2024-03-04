using System.Collections.Generic;
using UnityEngine;

public class SkillVampire : MonoBehaviour
{
    [SerializeField] private float _searchDistanse;
    [SerializeField] private HealsBar _healsBar;

    private List<Damage> _enemy = new List<Damage>();


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _enemy.Clear();

            SeachTarget();

            if(_enemy.Count > 0)
            {
                foreach(var damage in _enemy)
                {
                    damage.VampireDamage();
                    _healsBar.TakeHeals(damage.CurrentVampireDamage());
                }
            }
        }
    }

    private void SeachTarget()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _searchDistanse);

        foreach (var enemy in targets)
        {
            if (enemy.TryGetComponent<Damage>(out Damage damage))
            {
                _enemy.Add(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _searchDistanse);
    }
}
