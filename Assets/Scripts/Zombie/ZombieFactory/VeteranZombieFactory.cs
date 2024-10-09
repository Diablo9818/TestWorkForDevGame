using UnityEngine;

public class VeteranZombieFactory : IZombieFactory
{
    private Zombie veteranZombiePrefab;

    public VeteranZombieFactory(Zombie prefab)
    {
        veteranZombiePrefab = prefab;
    }

    public Zombie CreateZombie()
    {
        Zombie zombie = Object.Instantiate(veteranZombiePrefab);
        return zombie;
    }
}
