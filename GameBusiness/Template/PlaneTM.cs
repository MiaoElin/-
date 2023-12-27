using System.Numerics;
using Raylib_cs;
public struct PlaneTM
{
    public int typeID; // 1=我机，2=敌人飞行飞机 3=敌人固定飞机
    public Color color;
    public float radius;
    public float moveSpeed;
    public int hp;
    public int bulType; // 1=我机双弹 2=我机3弹 3=敌人双弹 4=敌人飞向我机单弹
    public Texture2D texture2D;
}