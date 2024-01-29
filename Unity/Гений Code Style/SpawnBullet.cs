using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delayForShoot;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Vector3 bulletTrack = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_bullet, transform.position + bulletTrack, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().transform.up = bulletTrack;
            bullet.GetComponent<Rigidbody>().velocity = bulletTrack * _speed;

            yield return _delayForShoot;
        }
    }
}