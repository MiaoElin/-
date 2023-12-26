using System.Numerics;
using Raylib_cs;

public struct BulletEntity
{
    public Vector2 pos1;
    public Vector2 pos2;
    public Vector2 pos3;
    public Color color;
    public float radius;
    public float moveSpeed;
    public bool isDead;
    public int id;
    public Vector2 firstDir;
    public sbyte typeID; //1=w玩家2子弹模式  2==玩家三子弹模式 3==飞行敌人子弹 4==固定敌人子弹

    // ===移动===
    public void PlayerBulMove2(float dt)
    {   // 玩家2发子弹模式
        Vector2 dir = new Vector2(0, -1);
        pos1 += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
        pos2 += Raymath.Vector2Normalize(dir) * moveSpeed * dt;

    }
    public void PlayerBulMove3(float dt)
    {
        // 待补充 玩家 3发子弹的 (xcos -ysin)(xsin +ycos)
        Vector2 dir1 = new Vector2(MathF.Sin(MathF.PI / -45), -1 * MathF.Cos(MathF.PI / -45));
        Vector2 dir2 = new Vector2(0, -1);
        Vector2 dir3 = new Vector2(MathF.Sin(MathF.PI / 45), -1 * MathF.Cos(MathF.PI / 45));
        pos1 += Raymath.Vector2Normalize(dir1) * moveSpeed * dt;
        pos2 += Raymath.Vector2Normalize(dir2) * moveSpeed * dt;
        pos3 += Raymath.Vector2Normalize(dir3) * moveSpeed * dt;


    }
    // 飞行敌人 子弹移动
    public void FEnemyBulMove(Vector2 dir, float dt)
    {
        pos1 += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
        pos2 += Raymath.Vector2Normalize(dir) * moveSpeed * dt;

    }
    // 固定敌人 子弹移动
    public void SEnemyBulMove(Vector2 dir, float dt)
    {
        pos1 += Raymath.Vector2Normalize(dir) * moveSpeed * dt;

    }

    // ====绘制====

    public void PlayerTwoBulDraw(AssetsContext asset, float scale)
    {
        float width = asset.bullet.Width;
        float heigth = asset.bullet.Height;
        Rectangle src = new Rectangle(0, 0, width, heigth);
        Rectangle dest1 = new Rectangle(pos1.X, pos1.Y, scale * width * 2 / 6, scale * width * 2 / 6);
        Rectangle dest2 = new Rectangle(pos2.X, pos2.Y, scale * width * 2 / 6, scale * width * 2 / 6);
        Vector2 center = new Vector2(scale * width * 2 / 6 / 2, scale * width * 2 / 6 / 2);
        Raylib.DrawTexturePro(asset.bullet, src, dest1, center, 0, Color.WHITE);
        Raylib.DrawTexturePro(asset.bullet, src, dest2, center, 0, Color.WHITE);
    }
    public void PlayerThreeBulDraw(AssetsContext asset, float scale)
    {
        Rectangle src = new Rectangle(0, 0, asset.bullet.Width, asset.bullet.Height);
        Rectangle dest1 = new Rectangle(pos1.X, pos1.Y, scale * 16 * 2/ 6, scale * 16 * 2 / 6);
        Rectangle dest2 = new Rectangle(pos2.X, pos2.Y, scale * 16 * 2/ 6, scale * 16 * 2 / 6);
        Rectangle dest3 = new Rectangle(pos3.X, pos3.Y, scale * 16 * 2 / 6, scale * 16 * 2 / 6);
        Vector2 center = new Vector2(scale * 16 * 2 / 6 / 2, scale * 16 * 2/ 6 / 2);
        Raylib.DrawTexturePro(asset.bullet, src, dest1, center, 0, Color.WHITE);
        Raylib.DrawTexturePro(asset.bullet, src, dest2, center, 0, Color.WHITE);
        Raylib.DrawTexturePro(asset.bullet, src, dest3, center, 0, Color.WHITE);
    }

    public void FEnemyBulDraw(AssetsContext asset, float scale)
    {
        Rectangle src = new Rectangle(0, 0, asset.bullet.Width, asset.bullet.Height);
        Rectangle dest1 = new Rectangle(pos1.X, pos1.Y, scale * 16 * 2/ 6, scale * 16 * 2 / 6);
        Rectangle dest2 = new Rectangle(pos2.X, pos2.Y, scale * 16 * 2/ 6, scale * 16 * 2 / 6);
        Vector2 center = new Vector2(scale * 16 * 2 / 6 / 2, scale * 16 * 2/ 6 / 2);
        Raylib.DrawTexturePro(asset.fenemybul, src, dest1, center, 0, Color.WHITE);
        Raylib.DrawTexturePro(asset.fenemybul, src, dest2, center, 0, Color.WHITE);

    }
    public void SEnemyBulDraw(AssetsContext asset, float scale)
    {
        Rectangle src = new Rectangle(0, 0, asset.bullet.Width, asset.bullet.Height);
        Rectangle dest1 = new Rectangle(pos1.X, pos1.Y, scale * 16 * 2/ 6, scale * 16 * 2 / 6);
        Vector2 center = new Vector2(scale * 16 * 2 / 6 / 2, scale * 16 * 2/ 6 / 2);
        Raylib.DrawTexturePro(asset.senemybul, src, dest1, center, 0, Color.WHITE);

    }
}