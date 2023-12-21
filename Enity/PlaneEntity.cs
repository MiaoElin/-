using System.Numerics;
using Raylib_cs;
public struct PlaneEntity
{
    public Color color;
    public Vector2 pos;
    public float moveSpeed;
    public float radius;
    public int hp;
    public bool isDead;
    public int id;
    public sbyte bulletType; //2==2发子弹 3==3发子弹

    public void Move(Vector2 dir, float dt)
    {
        pos += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
    }

    public void Draw()
    {
        Raylib.DrawCircleV(pos, radius, color);
    }

}