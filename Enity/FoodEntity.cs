using System.Numerics;
using Raylib_cs;
public struct FoodEntity{
    public Rectangle rect;
    public  Color color;
    public bool isDead;
    public sbyte ally;// 1=变子弹 2=加血

    public void Draw(){
        Raylib.DrawRectangleRec(rect,color);
    }
}