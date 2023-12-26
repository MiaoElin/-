using System.Numerics;
using Raylib_cs;

public static class BulletController
{
    
    public static void LogicTick(ref Context con, float dt, float scale)
    {
        BulletDomain.Spawn(ref con, dt, scale);
        BulletDomain.Move(ref con, dt);
        BulletDomain.Remove(ref con);

    }
    public static void DrawAll(ref Context con, float scale)
    {
        ref int bulletCount = ref con.BulletCount;
        ref BulletEntity[] Bullets = ref con.Bullets;
        ref AssetsContext asset = ref con.assetsContext;
        // 我机子弹 绘制
        for (int i = 0; i < bulletCount; i++)
        {
            var bul = Bullets[i];
            bul.Draw(scale);

        }





    }
}