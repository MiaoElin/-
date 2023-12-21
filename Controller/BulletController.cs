using System.Numerics;
using Raylib_cs;

public static class BulletController
{
    public static void LogicTick(ref Context con, float dt)
    {
        BulletDomain.Spawn(ref con, dt);
        BulletDomain.Move(ref con, dt);
        BulletDomain.Remove(ref con);

    }
    public static void DrawAll(ref Context con)
    {
        ref int bulletCount = ref con.BulletCount;
        ref BulletEntity[] Bullets = ref con.Bullets;
        // 我机子弹 绘制
        for (int i = 0; i < bulletCount; i++)
        {
            var bul = Bullets[i];
            if (bul.ally == 1)
            {
                Bullets[i].PlayerBulDraw1();

            }
            if(bul.ally==2){
                Bullets[i].PlayerBulDraw1();
            }
            // 敌人子弹 绘制
            if (bul.ally==3)
            {
                Bullets[i].FEnemyBulDraw();
            }
            if (bul.ally==4)
            {
                Bullets[i].SEnemyBulDraw();
            }

        }





    }
}