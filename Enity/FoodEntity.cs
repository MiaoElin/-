using System.Numerics;
using Raylib_cs;
public struct FoodEntity{
    public Rectangle rect;
    public  Color color;
    public bool isDead;
    public sbyte ally;// 1=变子弹 2=加血

    public void bulFoodDraw(AssetsContext asset, float scale)
    {
        Rectangle src = new Rectangle(0, 0, 16, 16);
        Rectangle dest = new Rectangle(rect.X, rect.Y, scale * 32/ 6, scale * 32/ 6);
        Raylib.DrawTexturePro(asset.bulFood, src, dest, Vector2.Zero, 0, Color.WHITE);
    }
    public void hpFoodDraw(AssetsContext asset, float scale)
    {
        Rectangle src = new Rectangle(0, 0, 16, 16);
        Rectangle dest = new Rectangle(rect.X, rect.Y, scale * 32 / 6, scale * 32/ 6);
        Raylib.DrawTexturePro(asset.hpFood, src, dest, Vector2.Zero, 0, Color.WHITE);
    }
}