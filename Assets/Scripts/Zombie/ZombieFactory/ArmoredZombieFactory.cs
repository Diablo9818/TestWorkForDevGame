using UnityEngine;

public class ArmoredZombieFactory : IZombieFactory
{
    private Zombie armoredZombiePrefab;

    public ArmoredZombieFactory(Zombie prefab)
    {
        armoredZombiePrefab = prefab;
    }

    public Zombie CreateZombie()
    {
        Zombie zombie = Object.Instantiate(armoredZombiePrefab);
        return zombie;
    }
}
