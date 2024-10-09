using UnityEngine;

public class RegularZombieFactory : IZombieFactory
{
    private Zombie regularZombiePrefab;

    public RegularZombieFactory(Zombie prefab)
    {
        regularZombiePrefab = prefab;
    }

    public Zombie CreateZombie()
    {
        Zombie zombie = Object.Instantiate(regularZombiePrefab);
        return zombie;
    }
}
