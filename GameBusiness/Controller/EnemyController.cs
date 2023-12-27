using System.Numerics;
using Raylib_cs;

public static class EnemyController
{
    enum Ally { X, player,fEnemy, sEnemy }
    public static void LogicTick(ref Context con, float dt,float scale)
    {
        EnemyDomain.Spawn(ref con,dt,scale);
        EnemyDomain.Move(ref con,dt);
        EnemyDomain.Remove(ref con);
    }
    public static void DrawAll(ref Context con, float scale)
    {         
        ref PlaneEntity[] Enemies = ref con.Enemies;   
        ref int EnemyCount = ref con.EnemyCount;
        ref AssetsContext asset = ref con.assetsContext;

        // 敌人 绘制
        for (int i = 0; i < EnemyCount; i++)
        {  
            var enemy = Enemies[i];
            enemy.Draw(scale);

        }

    }
}