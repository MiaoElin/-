using System.Numerics;
using Raylib_cs;

public static class EnemyController
{
    public static void LogicTick(ref Context con, float dt)
    {
        EnemyDomain.Spawn(ref con,dt);
        EnemyDomain.Move(ref con,dt);
        EnemyDomain.Remove(ref con);
    }
    public static void DrawAll(ref Context con)
    {
        ref PlaneEntity[] Enemies = ref con.Enemies;
        ref int EnemyCount = ref con.EnemyCount;

        // 敌人 绘制
        for (int i = 0; i < EnemyCount; i++)
        {   
            var enemy = Enemies[i];
            enemy.Draw();
        }
        

    }
}