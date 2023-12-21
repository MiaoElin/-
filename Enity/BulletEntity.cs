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
    public sbyte ally; //1=w玩家2子弹模式  2==玩家三子弹模式 3==飞行敌人子弹 4==固定敌人子弹

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
        Vector2 dir1=new Vector2 (MathF.Sin(MathF.PI/-45),-1*MathF.Cos(MathF.PI/-45));
        Vector2 dir2=new Vector2 (0,-1);
        Vector2 dir3=new Vector2 (MathF.Sin(MathF.PI/45),-1*MathF.Cos(MathF.PI/45));
        pos1+= Raymath.Vector2Normalize(dir1)*moveSpeed*dt;
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
    public void PlayerBulDraw1()
    {
        Raylib.DrawCircleV(pos1, radius, color);
        Raylib.DrawCircleV(pos2, radius, color);
        Raylib.DrawCircleV(pos3, radius, color);
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