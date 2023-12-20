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

    // ===移动===
    public void PlayerBulMove1(float dt)
    {   
        Vector2 dir = new Vector2(0, -1);
        pos1 += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
        pos2 += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
    }
    public void PlayerBulMove2(Vector2 dir, float dt)
    {
        // 待补充 玩家 3发子弹的
        pos1 += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
        pos2 += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
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
    public void PlayerBulDraw1()
    {
        Raylib.DrawCircleV(pos1, radius, color);
        Raylib.DrawCircleV(pos2, radius, color);
    }
    public void FEnemyBulDraw()
    {
        Raylib.DrawCircleV(pos1, radius, color);
        Raylib.DrawCircleV(pos2, radius, color);

    }
    public void SEnemyBulDraw()
    {
        Raylib.DrawCircleV(pos1, radius, color);

    }
}