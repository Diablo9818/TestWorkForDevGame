using System.Collections;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    [SerializeField] private ZombieSpawner _zombieSpawner;
    [SerializeField] private float _spawnIntervalLimit;
    [SerializeField] private int _timeToDecreaseInterval;

    private void Start()
    {
        StartCoroutine(IncreaseDifficulty());
    }

    private IEnumerator IncreaseDifficulty()
    {
        while (_zombieSpawner.SpawnInterval >= _spawnIntervalLimit)
        {
            yield return new WaitForSeconds(_timeToDecreaseInterval);
            _zombieSpawner.DecreaseInterval();
        }
    }
}
