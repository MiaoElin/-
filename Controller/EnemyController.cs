using System.Numerics;
using Raylib_cs;

public static class EnemyController
{
    enum Ally { X, player,none, fEnemy, sEnemy }
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
            Console.WriteLine ("llllll");
            var enemy = Enemies[i];
            if (enemy.bulType ==(int)Ally.fEnemy)
            {
                enemy.fEnemyDraw(asset, scale);
            }if(enemy.bulType==(int)Ally.sEnemy){
                enemy.sEnemyDraw(asset,scale);
            }

        }

    }
}