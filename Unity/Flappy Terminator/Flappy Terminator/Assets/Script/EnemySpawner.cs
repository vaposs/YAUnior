using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _maxPosition;
    [SerializeField] private Transform _minPosition;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delaySpawn;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(_delaySpawn));
    }

    private IEnumerator SpawnEnemy(float delay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

        while (true)
        {
            Instantiate(_enemy, new Vector3(transform.position.x, Random.RandomRange(_minPosition.transform.position.y, _maxPosition.transform.position.y), transform.position.z), Quaternion.identity);
            yield return waitForSeconds;
        }
    } 
}
