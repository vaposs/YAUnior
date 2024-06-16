using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFirstDrone : MonoBehaviour
{
    [SerializeField] private DronSpawner _dronSpawner;
    [SerializeField] private Button _button;

    public void Start()
    {
        Time.timeScale = 0;
    }

    public void Spawn()
    {
        _dronSpawner.Spawn();
        _button.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
