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
    public int bulType; //2==2发子弹 3==3发子弹
    public int typeID;

    public void Move(Vector2 dir, float dt)
    {
        pos += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
    }

    public void Draw(AssetsContext asset, float scale, int typeID)
    {
        Rectangle src = new Rectangle(0, 0, 32, 32);
        Rectangle dest = new Rectangle(pos.X, pos.Y, scale * 80 / 6, scale * 80 / 6);
        Vector2 center = new Vector2(scale * 80 / 6 / 2, scale * 80 / 6 / 2);
        if (typeID == 1)
        {
            Raylib.DrawTexturePro(asset.player, src, dest, center, 0, Color.WHITE);
        }
        if (typeID == 2)
        {
            Raylib.DrawTexturePro(asset.fenemy, src, dest, center, 0, Color.WHITE);
        }
        if (typeID == 3)
        {
            Raylib.DrawTexturePro(asset.senemy, src, dest, center, 0, Color.WHITE);
        }


    }
    // public void fEnemyDraw(AssetsContext asset, float scale)
    // {
    //     Rectangle src = new Rectangle(0, 0, 32, 32);
    //     Rectangle dest = new Rectangle(pos.X, pos.Y, scale * 80 / 6, scale * 80 / 6);
    //     Vector2 center = new Vector2(scale * 80 / 6 / 2, scale * 80 / 6 / 2);
    //     Raylib.DrawTexturePro(asset.fenemy, src, dest, center, 0, Color.WHITE);
    // }
    // public void sEnemyDraw(AssetsContext asset, float scale)
    // {
    //     Rectangle src = new Rectangle(0, 0, 32, 32);
    //     Rectangle dest = new Rectangle(pos.X, pos.Y, scale * 80 / 6, scale * 80 / 6);
    //     Vector2 center = new Vector2(scale * 80 / 6 / 2, scale * 80 / 6 / 2);
    //     Raylib.DrawTexturePro(asset.senemy, src, dest, center, 0, Color.WHITE);
    // }


}