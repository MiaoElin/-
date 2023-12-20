using System.Numerics;
using Raylib_cs;

public static class EnemyController
{
    public static void LogicTick(ref Context con, float dt)
    {
        ref PlaneEntity plane = ref con.plane;
        ref PlaneEntity[] flyEnemies = ref con.flyEnemies;
        ref PlaneEntity[] stayEnemies = ref con.stayEnemies;
        ref int flyEnemyCount = ref con.flyEnemyCount;
        ref int stayEnemyCount = ref con.stayEnemyCount;


        // 飞行敌人 生成；
        ref float fEnemySqwantimer = ref con.fEnemySqwantimer;
        ref float fEnemySqwanInterval = ref con.fEnemySqwanInterval;
        fEnemySqwantimer -= dt;
        if (fEnemySqwantimer <= 0)
        {
            fEnemySqwantimer = fEnemySqwanInterval;
            PlaneEntity newFlyEnemy = Factory.CreatePlane(RandomHelper.GetRandomPosOnTop(), Color.GRAY, 20, 60, 20, flyEnemyCount);
            flyEnemies[flyEnemyCount] = newFlyEnemy;
            flyEnemyCount++;
        }

        // 固定敌人 生成;
        ref float sEnemySqwantimer = ref con.sEnemySqwantimer;
        ref float sEnemySqwanInterval = ref con.sEnemySqwanInterval;
        sEnemySqwantimer -= dt;
        if (sEnemySqwantimer <= 0)
        {
            sEnemySqwantimer = sEnemySqwanInterval;
            PlaneEntity newStayEnemy = Factory.CreatePlane(RandomHelper.GetRandomPosOn_HalfTop(), Color.DARKGREEN, 30, 0, 20, stayEnemyCount);
            stayEnemies[stayEnemyCount] = newStayEnemy;
            stayEnemyCount++;
        }
        // 飞行敌人 移动
        for (int i = 0; i < flyEnemyCount; i++)
        {
            ref var fly = ref flyEnemies[i];
            Vector2 dir = plane.pos - fly.pos;
            fly.Move(dir, dt);
        }
        // 遍历所有的敌人 消除isDead的敌人
        for (int i = flyEnemyCount - 1; i >= 0; i--)
        {
            ref var fly = ref flyEnemies[i];
            if (fly.isDead)
            {
                Console.WriteLine("消除飞行敌人");
                RemoveUtil.RemoveEnemy(fly, i, flyEnemyCount, flyEnemies);
                flyEnemyCount -= 1;
            }
        }
        for (int i = stayEnemyCount - 1; i >= 0; i--)
        {
            ref var stay = ref stayEnemies[i];
            if (stay.isDead)
            {
                RemoveUtil.RemoveEnemy(stay, i, stayEnemyCount, stayEnemies);
                stayEnemyCount -= 1;
            }
        }

    }
    public static void DrawAll(ref Context con)
    {
        ref PlaneEntity[] flyEnemies = ref con.flyEnemies;
        ref PlaneEntity[] stayEnemies = ref con.stayEnemies;
        ref int flyEnemyCount = ref con.flyEnemyCount;
        ref int stayEnemyCount = ref con.stayEnemyCount;
        // 飞行敌人 绘制
        for (int i = 0; i < flyEnemyCount; i++)
        {
            var fly = flyEnemies[i];
            fly.Draw();
        }
        // 固定敌人 绘制
        for (int i = 0; i < stayEnemyCount; i++)
        {
            var stay = stayEnemies[i];
            stay.Draw();
        }
    }
}