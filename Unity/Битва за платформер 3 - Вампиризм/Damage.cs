using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private HealsBar _healsBar;
    [SerializeField] private int _damage = 50;
    [SerializeField] private int _damageVampireSkill = 1;
    [SerializeField] private int _timeVampireSkill = 6;

    private string _nameTriger = "Player";
    private int _currentVampireSkill = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.transform.tag == _nameTriger)
            {
                _healsBar.TakeDamage(_damage);
            }
        }
    }

    private IEnumerator VampireDamage(int delay)
    {
        for (int i = 0; i < delay; i++)
        {
            _healsBar.TakeDamage(_damageVampireSkill);
            yield return new WaitForSeconds(1f);
        }
    }

    public void VampireDamage()
    {
        if (_healsBar.TakeHealCurrent() > _damageVampireSkill * _timeVampireSkill)
        {
            _currentVampireSkill = _damageVampireSkill * _timeVampireSkill;
        }
        else
        {
            _currentVampireSkill = _healsBar.TakeHealCurrent();
        }

        StopAllCoroutines();
        StartCoroutine(VampireDamage(_currentVampireSkill));
    }

    public int CurrentVampireDamage()
    {
        return _currentVampireSkill;
    }
}