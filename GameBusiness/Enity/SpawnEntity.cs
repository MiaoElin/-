using System.Numerics;
using Raylib_cs;
public struct SpawnEntity
{
    public float fEnemySpawnInterval;
    public float fEnemySpawntimer;
    public float sEnemySpawnInterval;
    public float sEnemySpawntimer;

    public float planeBultimer;
    public float planeBulInterval;
    public float fEBulTimer;
    public float fEBulInterval;
    public float sEBulTimer;
    public float sEBulInterval;

    public float hpFoodTimer;
    public float hpFoodInterval;
    public float bulFoodTimer;
    public float bulFoodInterval;
    public SpawnEntity()
    {
        fEnemySpawntimer = 1f;
        fEnemySpawnInterval = 4f;

        sEnemySpawntimer = 1f;
        sEnemySpawnInterval = 8f;

        planeBultimer = 0;
        planeBulInterval = 0.2f;

        fEBulInterval = 4f;
        fEBulTimer = 0.5f;

        sEBulTimer = 0.5f;
        sEBulInterval = 3f;
        hpFoodTimer = 10f;
        hpFoodInterval = 10f;
        bulFoodTimer = 12f;
        bulFoodInterval = 12f;

    }

}