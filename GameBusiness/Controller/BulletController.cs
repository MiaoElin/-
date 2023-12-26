using System.Numerics;
using Raylib_cs;

public static class BulletController
{
    enum Ally { none, playerTwoBul, playerThreeBulles, fEnemyBul, sEnemyBul }
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
            if (bul.typeID == (int)Ally.playerTwoBul)
            {
                // 画我机 双弹
                bul.PlayerTwoBulDraw(asset,scale);
            }
            if (bul.typeID == (int)Ally.playerThreeBulles)
            {
                // 画我机 三弹
                bul.PlayerThreeBulDraw(asset,scale);

            }
            // 敌人子弹 绘制
            if (bul.typeID == (int)Ally.fEnemyBul)
            {
                Bullets[i].FEnemyBulDraw(asset,scale);
            }
            if (bul.typeID == (int)Ally.sEnemyBul)
            {
                Bullets[i].SEnemyBulDraw(asset,scale);
            }

        }





    }
}