using System.Numerics;
using Raylib_cs;

public static class EnemyDomain
{
    public static void Spawn(ref Context con, float dt,float scale)
    {

        ref PlaneEntity plane = ref con.plane;
        ref PlaneEntity[] Enemies = ref con.Enemies;
        ref int EnemyCount = ref con.EnemyCount;
        ref RandomService r=ref con.randomService;
        ref AssetsContext assetsContext= ref con.assetsContext;
        ref IDService iDService=ref con.iDService;

        // 飞行敌人 生成；
        ref float fEnemySqwantimer = ref con.spawnTimer.fEnemySpawntimer;
        ref float fEnemySqwanInterval = ref con.spawnTimer.fEnemySpawnInterval;
        fEnemySqwantimer -= dt;
        if (fEnemySqwantimer <= 0)
        {
            fEnemySqwantimer = fEnemySqwanInterval;
            // PlaneEntity newFlyEnemy = Factory.CreatePlane(2,3,r.GetRandomPosOnTop(scale), Color.GRAY, scale*20/6, 60, 20, EnemyCount);
            bool hasPlane =Factory.CreatePlane(assetsContext,iDService,2,r.GetRandomPosOnTop(scale),60,20,3,out PlaneEntity newFlyEnemy);
            if(hasPlane){
            Enemies[EnemyCount] = newFlyEnemy;
            EnemyCount++;
            }else{
               System.Console.WriteLine("default"); 
            }

        }

        // 固定敌人 生成;
        ref float sEnemySqwantimer = ref con.spawnTimer.sEnemySpawntimer;
        ref float sEnemySqwanInterval = ref con.spawnTimer.sEnemySpawnInterval;
        sEnemySqwantimer -= dt;
        if (sEnemySqwantimer <= 0)
        {
            sEnemySqwantimer = sEnemySqwanInterval;
            // PlaneEntity newStayEnemy = Factory.CreatePlane(3,4,r.GetRandomPosOn_HalfTop(scale), Color.DARKGREEN, scale*30/6, 0, 20, EnemyCount);
            bool hasPlane = Factory.CreatePlane(assetsContext,iDService,3,r.GetRandomPosOn_HalfTop(scale),0,20,4,out PlaneEntity newStayEnemy);
            Enemies[EnemyCount] = newStayEnemy;
            EnemyCount++;
        }
        // 
    }
    public static void Move(ref Context con, float dt)
    {
        ref PlaneEntity plane = ref con.plane;
        ref PlaneEntity[] Enemies = ref con.Enemies;
        ref int EnemyCount = ref con.EnemyCount;
        // 飞行敌人 移动
        for (int i = 0; i < EnemyCount; i++)
        {
            ref var fly = ref Enemies[i];
            Vector2 dir = plane.pos - fly.pos;
            fly.Move(dir, dt);
        }
    }
    public static void Remove(ref Context con)
    {
        ref PlaneEntity[] Enemies = ref con.Enemies;
        ref int EnemyCount = ref con.EnemyCount;
        // 遍历所有的敌人 消除isDead的敌人
        for (int i = EnemyCount - 1; i >= 0; i--)
        {
            ref var enemy = ref Enemies[i];
            if (enemy.isDead)
            {
                RemoveUtil.RemoveEnemy(enemy, i, EnemyCount, Enemies);
                EnemyCount -= 1;
            }
        }
    }
}