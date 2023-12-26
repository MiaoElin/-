using System.Numerics;
using Raylib_cs;

public static class IntersectUtil
{
    public static bool IsMouseIntersect(Vector2 mousePos, Rectangle rect)
    {
        Vector2 leftTop = new(rect.X, rect.Y);
        Vector2 rightBtton = new(rect.X + (int)rect.Width, rect.Y + (int)rect.Height);
        if (mousePos.X <= rightBtton.X && mousePos.X>= leftTop.X  &&mousePos.Y>=leftTop.Y&&mousePos.Y<=rightBtton.Y){
            return true;
        }else{
            return  false;
        }

    }
    public static bool IsCircleIntersect(PlaneEntity plane,BulletEntity bullet){
        float distance1=Vector2.Distance(plane.pos,bullet.pos);
        if(distance1<=plane.radius+bullet.radius){
            return true;
        }else{
            return false;
        }
    }
    public static bool IsRectangleIntersect(Rectangle rect,PlaneEntity plane){
        Vector2 leftTop = new Vector2(rect.X-plane.radius,rect.Y-plane.radius);
        Vector2 rightBottom =new Vector2((rect.X+(int)rect.Width)+plane.radius ,rect.Y+(int)rect.Height+plane.radius);
        if(plane.pos.X>=leftTop.X&&plane.pos.X<=rightBottom.X&&plane.pos.Y<=rightBottom.Y&&plane.pos.Y>=leftTop.Y){
            return true;
        }else{
            return false;
        }
    }
}