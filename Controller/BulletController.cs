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
        ref AssetsHelper asset = ref con.asset;
        // 我机子弹 绘制
        for (int i = 0; i < bulletCount; i++)
        {
            var bul = Bullets[i];
            if (bul.ally == (int)Ally.playerTwoBul)
            {
                // 画我机 双弹
                Rectangle src = new Rectangle(0, 0, scale*16/6,scale*16/6);
                Rectangle dest1 = new Rectangle(bul.pos1.X, bul.pos1.Y, scale * 16 / 6, scale * 16 / 6);
                Rectangle dest2 = new Rectangle(bul.pos2.X, bul.pos2.Y, scale * 16 / 6, scale * 16 / 6);
                Vector2 center =new Vector2(scale*16/6/2,scale*16/6/2);
                Raylib.DrawTexturePro(asset.bullet, src, dest1,center, 0, Color.WHITE);
                Raylib.DrawTexturePro(asset.bullet, src, dest2, center, 0, Color.WHITE);
            }
            if (bul.ally == (int)Ally.playerThreeBulles)
            {
                // 画我机 三弹
                Rectangle src = new Rectangle(0, 0, asset.bullet.Width, asset.bullet.Height);
                Rectangle dest1 = new Rectangle(bul.pos1.X, bul.pos1.Y, scale * 16 / 6, scale * 16 / 6);
                Rectangle dest2 = new Rectangle(bul.pos2.X, bul.pos2.Y, scale * 16 / 6, scale * 16 / 6);
                Rectangle dest3 = new Rectangle(bul.pos3.X, bul.pos3.Y, scale * 16 / 6, scale * 16 / 6);
                Vector2 center =new Vector2(scale*16/6/2,scale*16/6/2);
                Raylib.DrawTexturePro(asset.bullet, src, dest1, center, 0, Color.WHITE);
                Raylib.DrawTexturePro(asset.bullet, src, dest2, center, 0, Color.WHITE);
                Raylib.DrawTexturePro(asset.bullet, src, dest3, center, 0, Color.WHITE);

            }
            // 敌人子弹 绘制
            if (bul.ally == (int)Ally.fEnemyBul)
            {
                Bullets[i].FEnemyBulDraw();
            }
            if (bul.ally == (int)Ally.sEnemyBul)
            {
                Bullets[i].SEnemyBulDraw();
            }

        }





    }
}