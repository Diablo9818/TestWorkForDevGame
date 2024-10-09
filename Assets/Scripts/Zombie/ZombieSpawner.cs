using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private RegularZombie _regularZombiePrefab;
    [SerializeField] private VeteranZombie _veteranZombiePrefab;
    [SerializeField] private ArmoredZombie _armoredZombiePrefab;

    private Dictionary<string, IZombieFactory> zombieFactories;
    private float spawnInterval = 2.0f;

    public float SpawnInterval =>spawnInterval;

    private void Awake()
    {
        zombieFactories = new Dictionary<string, IZombieFactory>
        {
            { "Regular", new RegularZombieFactory(_regularZombiePrefab) },
            { "Veteran", new VeteranZombieFactory(_veteranZombiePrefab) },
            { "Armored", new ArmoredZombieFactory(_armoredZombiePrefab) }
        };
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public void DecreaseInterval()
    {
        spawnInterval -= 0.1f;
    }

    private void SpawnZombie()
    {
        float spawnChance = Random.Range(0f, 1f);
        IZombieFactory zombieFactory;

        if (spawnChance <= 0.1f)
        {
            zombieFactory = zombieFactories["Armored"];

            Zombie zombie = zombieFactory.CreateZombie();
            zombie.transform.position = GetRandomSpawnPosition();
            zombie.Init(_target);
        }

        else if (spawnChance <= 0.3f)
        {
            zombieFactory = zombieFactories["Veteran"];

            Zombie zombie = zombieFactory.CreateZombie();
            zombie.transform.position = GetRandomSpawnPosition();
            zombie.Init(_target);
        }

        else if (spawnChance <= 0.6f)
        {
            zombieFactory = zombieFactories["Regular"];

            Zombie zombie = zombieFactory.CreateZombie();
            zombie.transform.position = GetRandomSpawnPosition();
            zombie.Init(_target);
        }
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            SpawnZombie();
            yield return new WaitForSeconds(spawnInterval);

        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(0f, 4.5f);
        return new Vector3(x, y, 0);
    }

}
